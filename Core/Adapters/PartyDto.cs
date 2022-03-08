/* Empiria Insurtech *****************************************************************************************
*                                                                                                            *
*  Module   : Policies Management                          Component : Interface adapters                    *
*  Assembly : Empiria.Insurtech.dll                        Pattern   : Output DTO                            *
*  Type     : ContractPartyDto                             License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Output DTO for contract party.                                                                 *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

namespace Empiria.Insurtech.Policies.Adapters {

  public class PartyDto {

    public string UID {
      get; set;
    }

    public string Name {
      get; set;
    }

    public string Address {
      get; set;
    }

    public string City {
      get; set;
    }

    public string State {
      get; set;
    }

    public string Zip {
      get; set;
    }

    public DateTime DateOfBirth {
      get; set;
    }

    public string Gender {
      get; set;
    }

    public string RFC {
      get; set;
    }

    public string INE {
      get; set;
    }

    public string PhoneNumber {
      get; set;
    }

    public string Email {
      get; set;
    }

    public string CellPhoneNumber {
      get; set;
    }

    public string CURP {
      get; set;
    }

    public int TypeId {
      get; set;
    }

  }

}