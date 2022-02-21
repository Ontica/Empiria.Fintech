/* Empiria Insurtech *****************************************************************************************
*                                                                                                            *
*  Module   : Policies Management                          Component : Domain Layer                          *
*  Assembly : Empiria.Insurtech.dll                        Pattern   : Aggregate root                        *
*  Type     : Participant                                  License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Represents a party inside a contract.                                                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

using Empiria.Json;
using Empiria.Insurtech.Policies.Data;

namespace Empiria.Insurtech.Policies.Domain {

  /// <summary>Represents a party inside a contract.</summary>
  internal class ContractParty {

    #region Constructors and parsers

    public ContractParty() {
     //no-op
    }

    public ContractParty(int contractId, int partyId, int roleId) {
      this.ContractPartyTrackId = ContractPartyData.GetContractPartyTracKId();
      this.ContractPartyTrackUID = Guid.NewGuid().ToString();
      this.ContractPartyId = ContractPartyData.GetContractPartyId();
      this.ContractPartyTypeId = 100;
      this.ContractId = contractId;
      this.PartyId = partyId;
      this.RoleId = roleId;
      this.ContractPartyStatus = 'C';
      this.StartDate = DateTime.Now;
    }

    #endregion Constructors and parsers

    #region Public properties

    public int ContractPartyTrackId {
      get;
      private set;
    }

    public string ContractPartyTrackUID {
      get;
      private set;
    }

    public int ContractPartyId {
      get;
      private set;
    }

    public int ContractPartyTypeId {
      get;
      private set;
    }

    public int ContractId {
      get;
      private set;
    }

    public int PartyId {
      get;
      private set;
    }

    public int RoleId {
      get;
      private set;
    }

    [DataField("ContractExtData", IsOptional = true)]
    public JsonObject ExtData {
      get;
      private set;
    } = new JsonObject();

    public Char ContractPartyStatus {
      get;
      private set;
    }

    public DateTime StartDate {
      get;
      private set;
    }

    public DateTime EndDate {
      get;
      private set;
    } = ExecutionServer.DateMaxValue;

    public string ContractPartyTrackDIF {
      get;
      private set;
    } = String.Empty;

    #endregion Public properties

    #region Public methods

    internal void Save() {
      ContractPartyData.Write(this);
    }


    #endregion Public methods


    #region Private methods

    #endregion Private methods

  } // internal class ContractParty

} // namespace Empiria.Insurtech.Policies.Domain