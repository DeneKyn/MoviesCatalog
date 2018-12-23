using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Resources;
using System.Globalization;
using System.Reflection;

namespace MoviesCatalog
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        //readonly CultureInfo ci;
        const string ResourceId = "MoviesCatalog.Resource";

        static readonly Lazy<ResourceManager> resmgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public string Text { get; set; }
        public string Arg { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            var ci = Resource.Culture;
            var translation = resmgr.Value.GetString(Text, ci);

            if (translation == null)
            {
                translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
            }
            return translation;
        }
    }
}
