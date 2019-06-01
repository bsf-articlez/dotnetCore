using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindMvc.TagHelpers
{
    public class MoneyTagHelper : TagHelper
    {
        public decimal Amount { get; set; }
        public decimal? BaseAmount { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "strong";
            output.Content.SetContent(Amount.ToString("n2"));

            if (BaseAmount.HasValue)
            {
                if (Amount > BaseAmount) output.Attributes.SetAttribute("class", "text-success");
                else if (Amount < BaseAmount) output.Attributes.SetAttribute("class", "text-danger");
            }
        }
    }
}
