/* Empiria Insurtech *****************************************************************************************
*                                                                                                            *
*  Module   : Policies Management                          Component : Web Api                               *
*  Assembly : Empiria.Insurtech.WebApi.dll                 Pattern   : Controller                            *
*  Type     : PoliciesEditionController                    License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API used to edit information about insurance policies.                                     *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;
using System.Web.Http;

using Empiria.WebApi;

using Empiria.Insurtech.Policies.Adapters;
using Empiria.Insurtech.Policies.UseCases;

namespace Empiria.Insurtech.Policies.WebApi {

  /// <summary>Web API used to edit information about insurance policies.</summary>
  public class PoliciesEditionController : WebApiController {

    #region Web Apis

    [HttpPost]
    [Route("v1/insurtech/contracts")]
    public SingleObjectModel CreateContract([FromBody] ContractFields fields) {

      base.RequireBody(fields);
     

      using (var usecases = ContractsUseCases.UseCaseInteractor()) {
        ContractDto policy = usecases.CreateContract(fields);

        return new SingleObjectModel(base.Request, policy);
      }
    }


    #endregion Web Apis

  }  // class PoliciesEditionController

}  // namespace Empiria.Insurtech.Policies.WebApi