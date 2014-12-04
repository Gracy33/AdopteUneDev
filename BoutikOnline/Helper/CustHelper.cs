using AdopteUneDev.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoutikOnline.Helper
{
    public static class CustHelper
    {
        public static MvcHtmlString BoldTitle(this HtmlHelper Origin, string texte, string laclasse)
        {
            TagBuilder ta = new TagBuilder("h1");
            ta.InnerHtml = texte.ToUpper();
            ta.AddCssClass(laclasse);

            return new MvcHtmlString(ta.ToString());
        }

        public static MvcHtmlString MenuCategAndLang(this HtmlHelper origin, IEnumerable<Categories> categs)
        {

            TagBuilder principal = new TagBuilder("div");
            principal.AddCssClass("category-products");
            principal.AddCssClass("panel-group");
            principal.Attributes.Add("id", "accordian");

            foreach (Categories CurrentCateg in categs)
            {
                //<div class="panel panel-default">
                TagBuilder DivCateg = new TagBuilder("div");
                DivCateg.AddCssClass("panel-default");
                DivCateg.AddCssClass("panel");

                //<div class="panel-heading">
                TagBuilder DivHeading = new TagBuilder("div");
                DivHeading.AddCssClass("panel-heading");
                // <h4 class="panel-title">
                TagBuilder H4 = new TagBuilder("h4");
                H4.AddCssClass("panel-title");
                //<a data-toggle="collapse" data-parent="#accordian" href="#sportswear">
                TagBuilder atoggle = new TagBuilder("a");
                atoggle.Attributes.Add("data-parent", "#accordian");
                atoggle.Attributes.Add("data-toggle", "collapse");
                atoggle.Attributes.Add("href", "#" + CurrentCateg.CategLabel);
                //<span class="badge pull-right"><i class="fa fa-plus"></i></span>
                TagBuilder spanbadge = new TagBuilder("span");
                spanbadge.AddCssClass("pull-right");
                spanbadge.AddCssClass("badge");
                spanbadge.InnerHtml = "<i class=\"fa fa-plus\"></i>";

                atoggle.InnerHtml = spanbadge.ToString();
                atoggle.InnerHtml += CurrentCateg.CategLabel;
                H4.InnerHtml = atoggle.ToString();
                DivHeading.InnerHtml = H4.ToString();
                DivCateg.InnerHtml = DivHeading.ToString();


                //Ajout des langs
                // <div id="sportswear" class="panel-collapse collapse">
                TagBuilder tagLang = new TagBuilder("div");
                tagLang.Attributes.Add("id", CurrentCateg.CategLabel);
                tagLang.AddCssClass("collapse");
                tagLang.AddCssClass("panel-collapse");
                //<div class="panel-body">
                TagBuilder tagBody = new TagBuilder("div");
                tagBody.AddCssClass("panel-body");
                //ul
                TagBuilder tagUl = new TagBuilder("ul");
                foreach (ITLang item in CurrentCateg.ItLangs)
                {
                    TagBuilder tagLi = new TagBuilder("li");
                    tagLi.InnerHtml = "<a href=\"#\">" + item.ITLabel + "</a>";
                    //Ajout au ul
                    tagUl.InnerHtml += tagLi;

                }
                tagBody.InnerHtml = tagUl.ToString();
                tagLang.InnerHtml = tagBody.ToString();
                //Ajout categ
                DivCateg.InnerHtml += tagLang.ToString();
                //Ajout au principal
                principal.InnerHtml += DivCateg.ToString();

            }

            return new MvcHtmlString(principal.ToString());
        }

        public static MvcHtmlString Langs(this HtmlHelper origin, IEnumerable<ITLang> languages)
        {
            //            <div class="brands-name">
            //                <ul class="nav nav-pills nav-stacked">
            //                    <li><a href="#"> <span class="pull-right">(50)</span>.NET</a></li>
            //                    <li><a href="#"> <span class="pull-right">(56)</span>PHP</a></li>
            //                    <li><a href="#"> <span class="pull-right">(27)</span>JAVA</a></li>
            //                    <li><a href="#"> <span class="pull-right">(32)</span>ANDROID</a></li>
            //                    <li><a href="#"> <span class="pull-right">(5)</span>JQuery</a></li>
            //                </ul>
            //            </div>         

            TagBuilder first = new TagBuilder("div");
            first.AddCssClass("brands-name");

            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("nav-stacked");
            ul.AddCssClass("nav-pills");
            ul.AddCssClass("nav");

            foreach (ITLang lang in languages)
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder tagA = new TagBuilder("a");
                tagA.Attributes.Add("href", "#");

                TagBuilder span = new TagBuilder("span");
                span.AddCssClass("pull-right");

                foreach (Developer item in lang.Developers)
                {
                    span.InnerHtml = "(" + lang.Developers.Count().ToString() + ")";
                }

                tagA.InnerHtml = span.ToString();
                tagA.InnerHtml += lang.ITLabel;
                li.InnerHtml = tagA.ToString();
                ul.InnerHtml += li.ToString();
            }
            first.InnerHtml = ul.ToString();

            return new MvcHtmlString(first.ToString());
        }

        public static MvcHtmlString DeveloperOfTheMonth(this HtmlHelper origin, IEnumerable<Developer> devs)
        {
            string returnStr = "";
            foreach (Developer CurrentDev in devs)
            {
                returnStr += RenderPartialViewToString((Controller)HttpContext.Current.Session["CurrentController"], "_DevDisplay", CurrentDev);
            }

            return new MvcHtmlString(returnStr);
        }

        /// <summary>
        /// Renders the specified partial view to a string.
        /// </summary>
        /// <param name="controller">The current controller instance.</param>
        /// <param name="viewName">The name of the partial view.</param>
        /// <param name="model">The model.</param>
        /// <returns>The partial view as a string.</returns>
        public static string RenderPartialViewToString(Controller controller, string viewName, object model)
        {
            //Sert à afficher la photo, le nom de la categ,.... dans la vue
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = controller.ControllerContext.RouteData.GetRequiredString("action");
            }

            controller.ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                // Find the partial view by its name and the current controller context.
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);

                // Create a view context.
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);

                // Render the view using the StringWriter object.
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

    }
}