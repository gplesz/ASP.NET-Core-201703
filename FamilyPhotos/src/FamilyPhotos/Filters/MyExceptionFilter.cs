using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Filterek
/// https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters
///                                |                    |
///                              *Authorization Filters |
///                                |                    |
///                                |             -->-----      
///                                |             |      
///                              *Resource Filters
///                                |             |
///                                |             ---<----
///                                |                    |
///                               Model Binding         |
///                                |                    |
///                                |                    |
/// Action execution ----------<-*Action Filters        |
///                |                                    |
/// Action Result Conversation->- *Action Filters       |
///                                |                    |
///                              *Exception filters     |
///                                |                    |
///                                |                    |
///                              *Result filters        |
///                                |                    |
///                                |                    |
///                               Result execution--->---
///           
/// 
/// Exception filters handle unhandled exceptions that occur in 
/// controller creation, 
/// model binding, 
/// action filters, 
/// or action methods. 
/// 
/// They won't catch exceptions that occur in 
/// 
/// Resource filters, 
/// Result filters, or 
/// MVC Result execution.
/// 
/// Exception filters are good for trapping exceptions that occur within MVC actions, 
/// but they're not as flexible as error handling middleware. Prefer middleware for 
/// the general case, and use filters only where you need to do error handling 
/// differently based on which MVC action was chosen.
/// </summary>

namespace FamilyPhotos.Filters
{
    public class MyExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {

            
            base.OnException(context);
        }
    }


    public class MyExceptionFilter2 : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            throw new NotImplementedException();
        }
    }
}
