using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Managers
{

    public class UIManager : IInitializable
    {
        private Dictionary<Type, IUIElement> Pages { get; }
        private IUIElement CurrentPage { get; set; }
        private CanvasScaler CanvasScaler { get; set; }
        public GameObject Canvas { get; set; }
        public GameObject CanvasParent { get; set; }

        public UIManager()
        {
            Pages = new Dictionary<Type, IUIElement>();

            var uiView = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("Prefabs/UI/UICanvasView"));
            Canvas = uiView.transform.Find("Canvas").gameObject;
            CanvasParent = Canvas.transform.Find("SafeArea").gameObject;
        }

        public void Initialize()
        {
            CanvasScaler = Canvas.GetComponent<CanvasScaler>();
        }

        public void AddPage<T>(IUIElement page) where T : IUIElement
        {
            if (Pages.ContainsKey(typeof(T)) == false)
            {
                Pages.Add(typeof(T), page);
            }
        }

        public void RemovePage<T>()
        {
            Pages.Remove(typeof(T));
        }

        public void HideAllPages()
        {
            foreach (var item in Pages)
            {
                item.Value.Hide();
            }
        }
        
        public void HidePage<T>() where T : IUIElement
        {
            if (Pages.TryGetValue(typeof(T), out var page))
            {
                CurrentPage = page;
                CurrentPage?.Hide();
            }
        }

        public void ShowPage<T>(bool hideAll = false) where T : IUIElement
        {
            if (hideAll)
            {
                HideAllPages();
            }
            else
            {
                CurrentPage?.Hide();
            }

            if (Pages.TryGetValue(typeof(T), out var page))
            {
                CurrentPage = page;
                CurrentPage?.Show();
            }
        }

        public IUIElement GetPage<T>() where T : IUIElement
        {
            IUIElement page = null;
            foreach (var item in Pages.OfType<T>())
            {
                page = item;
                break;
            }

            return page;
        }
    }

}