/* Empiria Insurtech *****************************************************************************************
*                                                                                                            *
*  Module   : Policies Management                          Component : Use cases                             *
*  Assembly : Empiria.Insurtech.dll                        Pattern   : Use case interactor class             *
*  Type     : ContractsUseCases                            License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Use cases for contracts management.                                                            *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System.Diagnostics;

using Empiria.Services;

using Empiria.Insurtech.Policies.Adapters;
using Empiria.Insurtech.Policies.Domain;

namespace Empiria.Insurtech.Policies.UseCases {

  /// <summary>Use cases for contracts management.</summary>  
  public class ContractsUseCases : UseCase {

    #region Constructors and parsers

    protected ContractsUseCases() {
      // no-op
    }    

    static public ContractsUseCases UseCaseInteractor() {
      return UseCase.CreateInstance<ContractsUseCases>();
    }

    #endregion Constructors and parsers

    #region Use cases

    public ContractDto CreateContract(ContractFields fields) {
      Assertion.AssertObject(fields, "fields");
     
      var contract = new Contract(fields);
      contract.Save();

      var contractDto =  ContractMapper.Map(contract);
      return contractDto;
    }

    #endregion  Use cases


  } // public class ContractsUseCases : UseCase

} // namespace Empiria.Insurtech.Policies.UseCases