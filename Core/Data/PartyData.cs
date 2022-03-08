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
using System.Collections.Generic;

using Empiria.Data;
using Empiria.Insurtech.Policies.Domain;

namespace Empiria.Insurtech.Policies.Data {

  /// <summary>Data acccess layer for contract participant.</summary>
  static internal class PartyData {

    #region Public methods

    internal static void Delete(int partyId) {
      var op = $"UPDATE FTHParties SET PartyStatus = 'X' WHERE PartyId = {partyId} ";

      var dataOperation = DataOperation.Parse(op);

      DataWriter.Execute(dataOperation);  
    }


    internal static List<Party> GetParties(int contractId) {
      var op = $"SELECT * FROM FTHParties INNER JOIN FTHContractParties ON " +
               "FTHParties.PartyId = FTHContractParties.PartyId " +
              $"WHERE FTHContractParties.ContractId = {contractId} ";

      var dataOperation = DataOperation.Parse(op);

      return DataReader.GetPlainObjectList<Party>(dataOperation);
    }

    internal static Party GetParty(int id) {
      var op = $"SELECT * FROM FTHParties WHERE PartyId ={id}";
      
      var dataOperation = DataOperation.Parse(op);

      return DataReader.GetPlainObject<Party>(dataOperation);
    }


    internal static Party GetParty(string uid) {
      var op = $"SELECT * FROM FTHParties WHERE PartyTrackUID = '{uid}'";

      var dataOperation = DataOperation.Parse(op);

      return DataReader.GetPlainObject<Party> (dataOperation);
    }


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