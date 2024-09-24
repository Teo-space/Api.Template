public static class AnyExtension
{
    public static bool Any<T>(this ICollection<T> collection) => collection.Count > 0;
}
