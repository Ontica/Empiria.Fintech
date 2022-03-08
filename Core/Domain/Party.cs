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


    internal static Party Parse(int id) {
      return PartyData.GetParty(id);
    }


    internal static Party Parse(string uid) {
      return PartyData.GetParty(uid);
    }

    #endregion Constructors and parsers

    #region Public properties

    [DataField("PartyTrackId")]
    public int PartyTrackId {
      get;
      internal set;
    }

    [DataField("PartyTrackUID")]
    public string PartyTrackUID {
      get;
      internal set;
    }

    [DataField("PartyId")]
    public int PartyId {
      get;
      internal set;
    }

    [DataField("PartyTypeId")]
    public int PartyTypeId {
      get;
      internal set;
    }

    [DataField("PartyFullName")]
    public string PartyFullName {
      get;
      internal set;
    }

    [DataField("PartyAddress")]
    public string PartyAddress {
      get;
      internal set;
    }

    [DataField("PostalCode")]
    public string PostalCode {
      get;
      internal set;
    }

    [DataField("LocationId")]
    public int LocationId {
      get;
      internal set;
    }

    [DataField("StateId")]
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

    public string Email {
      get {
        return this.ExtData.Get("Email", string.Empty);
      }
      set {
        this.ExtData.Set("Email", value);
      }
    }

    [DataField("PartyKeywords")]
    public string PartyKeywords {
      get;
      internal set;
    }

    [DataField("PartyStatus", Default = 'C')]
    public char PartyStatus {
      get;
      internal set;
    } = 'C';

    [DataField("StartDate")]
    public DateTime StartDate {
      get;
      internal set;
    }

    [DataField("EndDate")]
    public DateTime EndDate {
      get;
      internal set;
    } = ExecutionServer.DateMaxValue;

    [DataField("PartyTrackDIF")]
    public string PartyTrackDIF {
      get;
      internal set;
    }

    #endregion Public properties


    internal void Delete() {
      PartyData.Delete(this.PartyId);
    }

    internal void Save() {
      PartyData.Write(this);
    }


    internal void Update(PartyFields fields) {
      Assertion.AssertObject(fields, "fields");

      this.PartyFullName = FieldPatcher.PatchField(fields.Name, this.PartyFullName);
      this.PartyAddress = FieldPatcher.PatchField(fields.Address, this.PartyAddress);
      this.PostalCode = FieldPatcher.PatchField(fields.Zip, this.PostalCode);
      this.DateOfBirth = FieldPatcher.PatchField(fields.DateOfBirth, this.DateOfBirth);
      this.Gender = FieldPatcher.PatchField(fields.Gender, this.Gender);
      this.RFC = FieldPatcher.PatchField(fields.RFC, this.RFC);
      this.INE = FieldPatcher.PatchField(fields.INE, this.INE);
      this.CURP = FieldPatcher.PatchField(fields.CURP, this.CURP);
      this.CellPhoneNumber = FieldPatcher.PatchField(fields.CellPhoneNumber, this.CellPhoneNumber);
      this.PhoneNumber = FieldPatcher.PatchField(fields.PhoneNumber, this.PhoneNumber);     
      this.Email = FieldPatcher.PatchField(fields.Email, this.Email);

    }

    #region Public methods

    #endregion Public methods

    #region Private methods

    private void Create(PartyFields participantField) {
      this.PartyTrackId = PartyData.GetPartyTrackId();
      this.PartyTrackUID = Guid.NewGuid().ToString();
      this.PartyId = PartyData.GetPartyId();
      this.PartyTypeId = participantField.TypeId;
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
      this.Email = participantField.Email;
    }

    #endregion Private methods

  } //class Participant

} // namespace Empiria.Insurtech.Policies.Domain