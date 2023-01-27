using SharCessing;
using SharCessing.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharPaint.Views
{
    public static class LayerManager
    {
        public static List<LayerView> layerViews = new List<LayerView>();
        public static LayerView activeLayer;

        public static void SetActiveLayer(LayerView view)
        {
            foreach (LayerView lv in layerViews)
            {
                if(lv != view)
                {
                    lv.IsActiveLayer = false;
                }
            }
            activeLayer = view;
        }

        public static Bitmap GetLayerImage(LayerView view)
        {
            return view.bmp;
        }

        public static Bitmap GetAllLayersAsImage(int width, int height)
        {
            return ImageHelpers.MergeMap(layerViews.Select(x => x.bmp).ToArray());
        }

        public static void DeleteLayer(LayerView view)
        {
            layerViews.Remove(view);
        }

        public static void AddLayerview(LayerView layerView)
        {
            activeLayer = layerView;
            layerViews.Add(layerView);
        }
    }
}
