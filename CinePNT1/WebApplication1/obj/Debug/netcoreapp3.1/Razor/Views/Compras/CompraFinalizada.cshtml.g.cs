#pragma checksum "C:\Users\Sendito\Desktop\Analista de Sistemas\1er Año\2do Cuatrimestre\PNT1\CinePNT1\CinePNT1\WebApplication1\Views\Compras\CompraFinalizada.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d7fddf63f6e0b82d9acc022b5f52796a63ecec1a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Compras_CompraFinalizada), @"mvc.1.0.view", @"/Views/Compras/CompraFinalizada.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Sendito\Desktop\Analista de Sistemas\1er Año\2do Cuatrimestre\PNT1\CinePNT1\CinePNT1\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Sendito\Desktop\Analista de Sistemas\1er Año\2do Cuatrimestre\PNT1\CinePNT1\CinePNT1\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7fddf63f6e0b82d9acc022b5f52796a63ecec1a", @"/Views/Compras/CompraFinalizada.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    public class Views_Compras_CompraFinalizada : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebCineMVC.Models.Compra>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Sendito\Desktop\Analista de Sistemas\1er Año\2do Cuatrimestre\PNT1\CinePNT1\CinePNT1\WebApplication1\Views\Compras\CompraFinalizada.cshtml"
  
    ViewData["Title"] = "Compra finalizada";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>¡¡Compra de entradas exitosa!!</h1>\r\n\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 15 "C:\Users\Sendito\Desktop\Analista de Sistemas\1er Año\2do Cuatrimestre\PNT1\CinePNT1\CinePNT1\WebApplication1\Views\Compras\CompraFinalizada.cshtml"
           Write(Html.DisplayNameFor(model => model.Dni));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 18 "C:\Users\Sendito\Desktop\Analista de Sistemas\1er Año\2do Cuatrimestre\PNT1\CinePNT1\CinePNT1\WebApplication1\Views\Compras\CompraFinalizada.cshtml"
           Write(Html.DisplayNameFor(model => model.Funcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "C:\Users\Sendito\Desktop\Analista de Sistemas\1er Año\2do Cuatrimestre\PNT1\CinePNT1\CinePNT1\WebApplication1\Views\Compras\CompraFinalizada.cshtml"
           Write(Html.DisplayNameFor(model => model.CantidadDeEntradas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 29 "C:\Users\Sendito\Desktop\Analista de Sistemas\1er Año\2do Cuatrimestre\PNT1\CinePNT1\CinePNT1\WebApplication1\Views\Compras\CompraFinalizada.cshtml"
           Write(Html.DisplayFor(model => model.Dni));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 32 "C:\Users\Sendito\Desktop\Analista de Sistemas\1er Año\2do Cuatrimestre\PNT1\CinePNT1\CinePNT1\WebApplication1\Views\Compras\CompraFinalizada.cshtml"
           Write(ViewData["Pelicula"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 36 "C:\Users\Sendito\Desktop\Analista de Sistemas\1er Año\2do Cuatrimestre\PNT1\CinePNT1\CinePNT1\WebApplication1\Views\Compras\CompraFinalizada.cshtml"
           Write(Html.DisplayFor(model => model.CantidadDeEntradas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 39 "C:\Users\Sendito\Desktop\Analista de Sistemas\1er Año\2do Cuatrimestre\PNT1\CinePNT1\CinePNT1\WebApplication1\Views\Compras\CompraFinalizada.cshtml"
           Write(ViewData["Fecha"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n             </td>\r\n\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n\r\n");
#nullable restore
#line 46 "C:\Users\Sendito\Desktop\Analista de Sistemas\1er Año\2do Cuatrimestre\PNT1\CinePNT1\CinePNT1\WebApplication1\Views\Compras\CompraFinalizada.cshtml"
Write(TempData["PeliculaHome"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebCineMVC.Models.Compra> Html { get; private set; }
    }
}
#pragma warning restore 1591
