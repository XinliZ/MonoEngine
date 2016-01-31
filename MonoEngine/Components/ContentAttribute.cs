using System;

namespace MonoEngine.Components
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ContentAttribute : Attribute
    {
        public ContentAttribute(string resourceName, ContentCategory contentCategory, LoadingPriority loadingPriority = LoadingPriority.Immediate)
        {
            this.ContentCategory = contentCategory;
            this.LoadingPriority = loadingPriority;
            this.ResourceName = resourceName;
        }

        public string ResourceName { get; private set; }
        public ContentCategory ContentCategory { get; private set; }
        public LoadingPriority LoadingPriority { get; private set; }
    }
}
