/* Empiria Insurtech *****************************************************************************************
*                                                                                                            *
*  Module   : Policies Management                          Component : Interface adapters                    *
*  Assembly : Empiria.Insurtech.dll                        Pattern   : Mapper class                          *
*  Type     : PartyDto                                     License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Mapping methods for contract parties                                                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;
using Empiria.Insurtech.Policies.Domain;

namespace Empiria.Insurtech.Policies.Adapters {

  /// <summary>Mapping methods for contract parties.</summary>
  static internal class PartyMapper {

    internal static PartyDto  Map(Party party) {

      var dto = new PartyDto {
        UID = party.PartyTrackUID,
        Name = party.PartyFullName,
        Address = party.PartyAddress,
        Zip = party.PostalCode,
        DateOfBirth = party.DateOfBirth,
        Gender = party.Gender,
        RFC = party.RFC,
        INE = party.INE,
        PhoneNumber = party.PhoneNumber,
        CellPhoneNumber = party.CellPhoneNumber,
        CURP = party.CURP,
        TypeId =  party.PartyTypeId
      };
      return dto;
      throw new NotImplementedException();
    }


  }
}