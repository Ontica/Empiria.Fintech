/* Empiria Insurtech *****************************************************************************************
*                                                                                                            *
*  Module   : Policies Management                          Component : Interface adapters                    *
*  Assembly : Empiria.Insurtech.dll                        Pattern   : Output DTO                            *
*  Type     : ContractTypeDto                                  License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Output DTO for a contract type.                                                               *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

namespace Empiria.Insurtech.Policies.Adapters {

  /// <summary>Output DTO for a contract type. </summary>
  public class ContracTypeDto {

    public string UID {
      get; internal set;
    }

    public string Name {
      get; internal set;
    }


  }  // class ContracTypeDto


} // namespace Empiria.Insurtech.Policies.Adapters