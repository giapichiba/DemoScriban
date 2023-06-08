using DemoScriban.Extensions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Scriban;
using Scriban.Runtime;
using Scriban.Syntax;
using System.Dynamic;
using System.Reflection;

namespace DemoScriban.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    public string TemplateHtml { get; set; }
    public string Data { get; set; }
    public string Result { get; set; }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        TemplateHtml = Request.Form["Template"];
        Data = Request.Form["Data"];

        //tên của biến sẽ là từ bắt đầu của object
        // ví dụ tên biến là model
        //lúc gọi ngoài template sẽ phải là: mode.xxx
        var data = JsonConvert.DeserializeObject<ExpandoObject>(Data);
        var result = ScribanExtension.Render(TemplateHtml, new { data });

        Result = result;
    }
    
}