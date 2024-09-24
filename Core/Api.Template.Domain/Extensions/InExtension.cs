public static class InExtension
{
    public static bool In<T>(this T element, params T[] elements) => elements.Contains(element);
    public static bool NotIn<T>(this T element, params T[] elements) => !elements.Contains(element);

}
