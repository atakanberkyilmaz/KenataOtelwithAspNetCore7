using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using HtmlHelper = Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper;
using TagRenderMode = System.Web.Mvc.TagRenderMode;

public static class CustomHtmlHelpers
{
    public static IHtmlContent CustomTextBoxFor<TModel, TProperty>(
        this IHtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TProperty>> expression,
        object htmlAttributes)
    {
        var metadata = htmlHelper.MetadataProvider.GetMetadataForProperty(typeof(TModel), ExpressionHelper.GetExpressionText(expression));
        var propertyName = metadata.Name;

        var tagBuilder = new System.Web.Mvc.TagBuilder("input");
        tagBuilder.Attributes.Add("type", "text");
        tagBuilder.Attributes.Add("name", propertyName);
        tagBuilder.Attributes.Add("id", propertyName);

        var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
        tagBuilder.MergeAttributes(attributes);

        var result = tagBuilder.ToString(TagRenderMode.SelfClosing);
        return new HtmlString(result);
    }
}
