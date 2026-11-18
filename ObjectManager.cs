using System;
using System.Collections.Generic;
using System.Text;
using VorticeDirectX_Sample;
using VorticeDirectX11_Template;

namespace Windows_VideoEditor {
    public class ObjectManager {

        private List<BaseObject> objectList_ = new List<BaseObject>();

        public ObjectManager() {
        }

        public void Init() {
            objectList_.Clear();
        }

        public void AddObject(BaseObject obj) {
            objectList_.Add(obj);
            obj.Init();

            Render.DrawWindow.Timeline.Items.Add(obj.Name);
        }

        public void UpdateAllObject() {
            for (int i = 0; i < objectList_.Count; i++) {
                BaseObject obj = objectList_[i];
                if (obj != null) {
                    obj.Update();
                }
            }
        }

        public void DrawAllObject() {
            for (int i = 0; i < objectList_.Count; i++) {
                BaseObject obj = objectList_[i];
                if (obj != null) {
                    obj.Draw();
                }
            }
        }
    }
}
