using UnityEngine;

namespace Common.Extensions
{
    public static class RectTransformExtensions
    {
        public static bool AreRectTransformsOverlapping(RectTransform rectTransform1, RectTransform rectTransform2)
        {
            Rect rect1 = GetWorldRect(rectTransform1);
            Rect rect2 = GetWorldRect(rectTransform2);

            return rect1.Overlaps(rect2);
        }

        private static Rect GetWorldRect(RectTransform rectTransform)
        {
            Vector3[] corners = new Vector3[4];
            rectTransform.GetWorldCorners(corners);

            float x = corners[0].x;
            float y = corners[0].y;
            float width = corners[2].x - corners[0].x;
            float height = corners[2].y - corners[0].y;

            return new Rect(x, y, width, height);
        }
    }
}