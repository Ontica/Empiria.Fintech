/* Empiria Insurtech *****************************************************************************************
*                                                                                                            *
*  Module   : Policies Management                          Component : Use cases                             *
*  Assembly : Empiria.Insurtech.dll                        Pattern   : Use case interactor class             *
*  Type     : PoliciesUseCases                             License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Use cases for insurance policies management.                                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

using Empiria.Services;

using Empiria.Insurtech.Policies.Adapters;

namespace Empiria.Insurtech.Policies.UseCases {

  /// <summary>Use cases for accounts chart management.</summary>
  public class PoliciesUseCases : UseCase {

    #region Constructors and parsers

    protected PoliciesUseCases() {
      // no-op
    }

    static public PoliciesUseCases UseCaseInteractor() {
      return UseCase.CreateInstance<PoliciesUseCases>();
    }

    #endregion Constructors and parsers

    #region Use cases

    public PolicyDto CreatePolicy(PolicyFields fields) {
      return new PolicyDto();
    }

    #endregion Use cases

  }  // class PoliciesUseCases

}  // namespace Empiria.Insurtech.Policies.UseCases
