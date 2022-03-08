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
using System;

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

      contract.SaveContractParties(fields.Parties);

      var contractDto =  ContractMapper.Map(contract);
      return contractDto;
    }


    public void DeleteContract(string uid) {
      Assertion.Assert(uid != String.Empty, "uid");

      var contract = Contract.Parse(uid);

      contract.DelteteContractParties();
      contract.Delete();
    }


    public FixedList<ContracTypeDto> GetContractTypes() {
      FixedList<ContractType> list = ContractType.GetList();

      return ContracTypeMapper.Map(list);     
    }


    public ContractDto UpdateContract(ContractFields fields) {
      Assertion.AssertObject(fields, "fields");

      var contract = Contract.Parse(fields.ContractUID);
      contract.Update(fields);

      contract.UpdateParties(fields.Parties);

      contract.Save();
      return ContractMapper.Map(contract);
    }
    
    #endregion  Use cases


  } // public class ContractsUseCases : UseCase

} // namespace Empiria.Insurtech.Policies.UseCases