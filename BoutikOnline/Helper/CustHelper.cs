using AdopteUneDev.DAL;
using System;
using System.Collections.Generic;
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

        public static MvcHtmlString Devs(this HtmlHelper origin, IEnumerable<Developer> devs)
        {
            //<div class="col-sm-4">
            //            <div class="product-image-wrapper">
            //                <div class="single-products">
            //                    <div class="productinfo text-center">
            //                        <img src="~/Content/images/home/product1.jpg" alt="" />
            //                        <h2>€56/Hours</h2>
            //                        <p>Polyvalent Web Developer</p>
            //                        <a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Add to cart</a>
            //                    </div>
            //                    <div class="product-overlay">
            //                        <div class="overlay-content">
            //                            <h2>€56/Hours</h2>
            //                            <p>Polyvalent Web Developer</p>
            //                            <a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Add to cart</a>
            //                        </div>
            //                    </div>
            //                </div>
            //                <div class="choose">
            //                    <ul class="nav nav-pills nav-justified">
            //                        <li><a href="#"><i class="fa fa-plus-square"></i>Add to wishlist</a></li>
            //                        <li><a href="#"><i class="fa fa-plus-square"></i>Add to compare</a></li>
            //                    </ul>
            //                </div>
            //            </div>
            //        </div>

            TagBuilder firstDiv = new TagBuilder("div");
            firstDiv.AddCssClass("col-sm-4");

            TagBuilder secondDiv = new TagBuilder("div");
            secondDiv.AddCssClass("product-image-wrapper");

            TagBuilder thirdDiv = new TagBuilder("div");
            thirdDiv.AddCssClass("single-products");

            TagBuilder fourthDiv = new TagBuilder("div");
            fourthDiv.AddCssClass("text-center");
            fourthDiv.AddCssClass("productinfo");
            foreach (Developer dev in devs)
            {
                TagBuilder tagImg = new TagBuilder("img");
                tagImg.Attributes.Add("src", "~/Content/images/home/" + dev.DevPicture);

                TagBuilder tagH = new TagBuilder("h2");
                tagH.InnerHtml = dev.DevHourCost + "€/hour";

                foreach (ITLang lang in dev.ItLangs)
                {
                    foreach (Categories CurrentCateg in lang.Categories)
                    {
                        TagBuilder tagP = new TagBuilder("p");
                        tagP.InnerHtml = CurrentCateg.CategLabel;
                    

                    TagBuilder tagA = new TagBuilder("a");
                    tagA.AddCssClass("add-to-cart");
                    tagA.AddCssClass("btn-default");
                    tagA.AddCssClass("btn");
                    tagA.Attributes.Add("href", "#");

                    TagBuilder tagI = new TagBuilder("i");
                    tagI.AddCssClass("fa-shopping-cart");
                    tagI.AddCssClass("fa");
                    tagI.InnerHtml = "Add to cart";

                    tagA.InnerHtml = tagI.ToString();
                    fourthDiv.InnerHtml = tagA.ToString();
                    fourthDiv.InnerHtml += tagP.ToString();
                    }
                }
                fourthDiv.InnerHtml += tagH.ToString();
                thirdDiv.InnerHtml = fourthDiv.ToString();
                secondDiv.InnerHtml = thirdDiv.ToString();
                firstDiv.InnerHtml = secondDiv.ToString();
            }

            return new MvcHtmlString(firstDiv.ToString());
        }

    }
}