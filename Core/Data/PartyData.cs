/* Empiria Insurtech *****************************************************************************************
*                                                                                                            *
*  Module   : Policies Management                          Component : Data Access Layer                     *
*  Assembly : Empiria.Insurth.dll                          Pattern   : Data Service                          *
*  Type     : ContractData                                 License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Data acccess layer for contract participant.                                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

using Empiria.Data;
using Empiria.Insurtech.Policies.Domain;

namespace Empiria.Insurtech.Policies.Data {

  /// <summary>Data acccess layer for contract participant.</summary>
  static internal class PartyData {

    #region Public methods

    static internal int GetPartyTrackId() {
      return GetNextId("PartyTrackId");
    }

    static internal int GetPartyId() {
      return GetNextId("PartyTrackId");
    }

    internal static void Write(Party o) {
      var op = DataOperation.Parse("writeFTHParties", o.PartyTrackId, o.PartyTrackUID,
                                  o.PartyId, o.PartyTypeId, o.PartyFullName, o.PartyAddress,
                                  o.PostalCode, o.LocationId, o.StateId, o.ExtData.ToString(),
                                 o.PartyKeywords, o.PartyStatus, o.StartDate, o.EndDate, o.PartyTrackDIF);

      DataWriter.Execute(op);
    }

    #endregion Public methods

    #region Private methods

    static private int GetNextId(string fieldId) {
      var sql = "SELECT max(" + fieldId + ") from  FTHParties";

      var op = DataOperation.Parse(sql);

      if (op == null) {
        return 1;
      }

      return Empiria.Data.DataReader.GetScalar<int>(op) + 1;      
    }

   

    #endregion Private methods
  } // class ParticiantData

} //  Empiria.Insurtech.Policies.Data