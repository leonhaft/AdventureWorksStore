using AdventureWorksStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorksStore.Domain.Entities;
using System.Net.Mail;
using System.Net;

namespace AdventureWorksStore.Domain.Concrete
{
    public class EMailOrderProcessor : IOrderProcess
    {
        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {
            //using (var smtpClient = new SmtpClient())
            //{
            //    smtpClient.EnableSsl = true;
            //    smtpClient.Host = "";
            //    smtpClient.Port = 3243;
            //    smtpClient.UseDefaultCredentials = false;
            //    smtpClient.Credentials = new NetworkCredential("", "");


            //    StringBuilder body = new StringBuilder().AppendLine("A new order has been submitted").AppendLine("---").AppendLine("Items:");
            //    foreach (var line in cart.CartItems)
            //    {
            //        var subtotal = line.Product.ListPrice * line.Quantity;
            //        body.AppendFormat("{0} x {1} (subtotal: {2:c}", line.Quantity, line.Product.Name, subtotal);
            //    }
            //    body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue()).AppendLine("---").AppendLine("Ship to:").AppendLine(shippingInfo.Name).AppendLine(shippingInfo.Line1).AppendLine(shippingInfo.Line2 ?? "").AppendLine(shippingInfo.Line3 ?? "").AppendLine(shippingInfo.City).AppendLine(shippingInfo.State ?? "").AppendLine(shippingInfo.Country).AppendLine(shippingInfo.Zip).AppendLine("---").AppendFormat("Gift wrap: {0}", shippingInfo.GiftWrap ? "Yes" : "No");
            //    MailMessage mailMessage = new MailMessage("", "", "New order submitted!", body.ToString());
            //    smtpClient.Send(mailMessage);
            //}

        }
    }
}
