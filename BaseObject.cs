using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace VorticeDirectX11_Template {
    public abstract class BaseObject {

        public string Name {
            get; private set;
        }
        public int DrawHighOrder {
            get; set;
        } = 10000;
        public bool IsDead {
            get; private set;
        }
        public string? Tag {
            get; set;
        } = null;
        public BaseObject? Parent {
            get; set;
        } = null;
        public List<BaseObject> ChildList {
            get; set;
        } = new List<BaseObject>();
        public Transform Transform {
            get; set;
        } = new Transform();

        public BaseObject(string name) {
            Name = name;
        }

        public abstract void Init();
        public abstract void Update();
        public abstract void Draw();
        public virtual void OnCollision() { }

    }
}
