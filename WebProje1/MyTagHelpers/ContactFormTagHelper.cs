using Microsoft.AspNetCore.Razor.TagHelpers;

[HtmlTargetElement("contact-form")]
public class ContactFormTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.SetAttribute("style", "margin:50px;");
        output.Content.AppendHtml("<h3 style='color:#031454;'>İletişim Formu</h3>");

        var formContent = @"
            <div class='container'>
                <form id='contact' action='' method=''>
                    <h2 style='color:#fff;'>İletişim Formu</h2>
                    <div class='form-control'>
                        <input placeholder='Adınız Soyadınız' type='text' required autofocus>
                    </div>
                    <div class='form-control'>
                        <input placeholder='E-Posta Adresiniz' type='email' required>
                    </div>
                    <div class='form-control'>
                        <input placeholder='Konu' type='text' required>
                    </div>
                    <div class='form-control'>
                        <textarea placeholder='Lütfen Mesajınızı Buraya Yazın..' required></textarea>
                    </div>
                    <div class='form-control'>
                        <button name='submit' type='submit' id='submit'>GÖNDER</button>
                    </div>
                </form>
            </div>
        ";

        output.Content.AppendHtml(formContent);
    }
}
