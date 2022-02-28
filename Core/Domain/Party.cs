/* Empiria Insurtech *****************************************************************************************
*                                                                                                            *
*  Module   : Policies Management                          Component : Domain Layer                          *
*  Assembly : Empiria.Insurtech.dll                        Pattern   : Aggregate root                        *
*  Type     : Participant                                  License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Represents a party in a contract.                                                              *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

using Empiria.Json;
using Empiria.Insurtech.Policies.Adapters;
using Empiria.Insurtech.Policies.Data;

namespace Empiria.Insurtech.Policies.Domain {

  /// <summary>Represents a party in a contract.</summary>
  internal class Party {

    #region Constructors and parsers

    public Party() {
    }

    public Party(PartyFields participantField) {
      Create(participantField);     
    }   

    #endregion Constructors and parsers

    #region Public properties

    public int PartyTrackId {
      get;
      internal set;
    }

    public string PartyTrackUID {
      get;
      internal set;
    }

    public int PartyId {
      get;
      internal set;
    }

    public int PartyTypeId {
      get;
      internal set;
    }

    public string PartyFullName {
      get;
      internal set;
    }

    public string PartyAddress {
      get;
      internal set;
    }

    public string PostalCode {
      get;
      internal set;
    }

    public int LocationId {
      get;
      internal set;
    }

    public int StateId {
      get;
      internal set;
    }

    [DataField("PartyExtData", IsOptional = true)]
    public JsonObject ExtData {
      get;
      internal set;
    } = new JsonObject();

    internal DateTime DateOfBirth {
      get {
        return this.ExtData.Get<DateTime>("DateOfBirth");
      }
      set {
        this.ExtData.Set("DateOfBirth", value);
      }
    }

    internal string Gender {
      get {
        return this.ExtData.Get("Gender", string.Empty);
      }
      set {
        this.ExtData.Set("Gender", value);
      }
    }

    public string RFC {
      get {
        return this.ExtData.Get("RFC", string.Empty);
      }
      set {
        this.ExtData.Set("RFC", value);
      }
    }

    public string INE {
      get {
        return this.ExtData.Get("INE", string.Empty);
      }
      set {
        this.ExtData.Set("INE", value);
      }
    }

    public string PhoneNumber {
      get {
        return this.ExtData.Get("PhoneNumber", string.Empty);
      }
      set {
        this.ExtData.Set("PhoneNumber", value);
      }
    }

    public string CellPhoneNumber {
      get {
        return this.ExtData.Get("CellPhoneNumber", string.Empty);
      }
      set {
        this.ExtData.Set("CellPhoneNumber", value);
      }
    }

    public string CURP {
      get {
        return this.ExtData.Get("CURP", string.Empty);
      }
      set {
        this.ExtData.Set("CURP", value);
      }
    }

    public string PartyKeywords {
      get;
      internal set;
    }

    public char PartyStatus {
      get;
      internal set;
    }

    public DateTime StartDate {
      get;
      internal set;
    }

    public DateTime EndDate {
      get;
      internal set;
    } = ExecutionServer.DateMaxValue;

    public string PartyTrackDIF {
      get;
      internal set;
    }

    #endregion Public properties


    internal void Save() {
      PartyData.Write(this);
    }

    #region Public methods

    #endregion Public methods

    #region Private methods

    private void Create(PartyFields participantField) {
      this.PartyTrackId = PartyData.GetPartyTrackId();
      this.PartyTrackUID = Guid.NewGuid().ToString();
      this.PartyId = PartyData.GetPartyId();
      this.PartyTypeId = 0;
      this.PartyFullName = participantField.Name;
      this.PartyAddress = participantField.Address;
      this.PostalCode = participantField.Zip;     
      this.LocationId = -1;
      this.StateId = 0;
      this.DateOfBirth = participantField.DateOfBirth;
      this.Gender = participantField.Gender;
      this.RFC = participantField.RFC;
      this.INE = participantField.INE;
      this.CURP = participantField.CURP;
      this.CellPhoneNumber = participantField.CellPhoneNumber;
      this.PhoneNumber = participantField.PhoneNumber;
      this.PartyKeywords = "";
      this.PartyStatus = 'C';
      this.StartDate = DateTime.Today;
      this.EndDate = ExecutionServer.DateMaxValue;
      this.PartyTrackDIF = "";
      
    }

    #endregion Private methods

  } //class Participant

} // namespace Empiria.Insurtech.Policies.Domain