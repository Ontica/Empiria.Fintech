/* Empiria Insurtech *****************************************************************************************
*                                                                                                            *
*  Module   : Policies Management                          Component : Domain Layer                          *
*  Assembly : Empiria.Insurtech.dll                        Pattern   : Aggregate root                        *
*  Type     : Contractor                                   License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Represent a contract.                                                                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;
using System.Text;

using Empiria.Json;

using Empiria.Insurtech.Policies.Adapters;
using Empiria.Insurtech.Policies.Data;


namespace Empiria.Insurtech.Policies.Domain { 
   

  /// <summary>Enumerates the different contractparty types.</summary>
  public enum ContractPartyType {

    Contratante = 1,

    Beneficiario = 2

  }  // ContractPartyType

  /// <summary>Represent a contract.</summary>
  internal class Contract {

    #region Constructors and parsers

    public Contract() {
      //no-op
    }

    public Contract(ContractFields fields) {
      Create(fields);
    }

    internal static Contract Parse(int id) {
      return ContractData.GetContract(id);
    }

    internal static Contract Parse(string uid) {
      return ContractData.GetContract(uid);
    }

    #endregion Constructors and parsers

    #region Public properties

    [DataField("ContractTrackId")]
    public int ContractTrackId {
      get;
      private set;
    }


    [DataField("ContractTrackUID")]
    public string ContractTrackUID {
      get;
      private set;
    }
       

    [DataField("ContractId")]
    public int ContractId {
      get;
      private set;
    }


    [DataField("ContractTypeId")]
    public ContractType ContractType {
      get;
      private set;
    }

    [DataField("ContractNo")]
    public string ContractNo {
      get;
      private set;
    }


    [DataField("ContractExtData", IsOptional = true)]
    public JsonObject ExtData {
      get;
      private set;
    } = new JsonObject();

    internal string ContractPayment {
      get {
        return this.ExtData.Get("ContractPayment", string.Empty);
      }
     private set {
        this.ExtData.SetIfValue("ContractPayment", value);
      }
    }


    [DataField("ContractKeywords")]
    public string ContractKeywords {
      get;
      private set;
    }


    [DataField("ModifiedById")]
    public int ModifiedById {
      get;
      private set;
    }


    [DataField("ContractStatus", Default = 'C')]
    public char ContractStatus {
      get;
      private set;
    } = 'C';


    [DataField("StartDate")]
    public DateTime StartDate {
      get;
      private set;
    }


    [DataField("EndDate")]
    public DateTime EndDate {
      get;
      private set;
    } = ExecutionServer.DateMaxValue;


    [DataField("ContractTrackDIF")]
    public string ContractTrackDIF {
      get;
      private set;
    }


    #endregion Public properties

    #region Methods


    internal void Save() {   
      ContractData.Write(this);  
    }


    internal void Update(ContractFields fields) {
      Assertion.AssertObject(fields, "fields");
      this.ContractType = FieldPatcher.PatchField(fields.ContractTypeUID, this.ContractType);
      this.ContractPayment = FieldPatcher.PatchField(fields.PaymentType, this.ContractPayment);
      this.StartDate = FieldPatcher.PatchField(Convert.ToDateTime(fields.StartDate),this.StartDate);
    }


    internal void UpdateParty(PartyFields fields) {
      var party = Party.Parse(fields.UID);

      party.Update(fields);

      party.Save();
    }

    #endregion Methods

    #region Private methods

    private void Create(ContractFields fields) {
      this.ContractTrackId = ContractData.GetContractTrackId();
      this.ContractTrackUID = Guid.NewGuid().ToString();
      this.ContractId = ContractData.GetContractId();
      this.ContractType = ContractType.Parse(fields.ContractTypeUID);
      this.ContractNo = GenerateContractNumber();
      this.ContractKeywords = "";
      this.ModifiedById = -1;
      this.ContractStatus = 'C';
      this.StartDate = DateTime.Today;
      this.EndDate = ExecutionServer.DateMaxValue;
      this.ContractTrackDIF = "";
      this.ContractPayment = fields.PaymentType; 

      CreateContratante(fields.Contractor);
      CreateBeneficiary(fields.Beneficiary);
    }

    private void CreateContratante(PartyFields contractorFields) {
      var contratante = new Party(contractorFields);
      contratante.Save();

      var contratanteRelacion = new ContractParty(this.ContractId, contratante.PartyId, (int) ContractPartyType.Contratante);
      contratanteRelacion.Save();
    }

    private void CreateBeneficiary(PartyFields beneficiaryFields) {
      var benefeciary = new Party(beneficiaryFields);
      benefeciary.Save();

      var benefeciaryRelation = new ContractParty(this.ContractId, benefeciary.PartyId, (int) ContractPartyType.Beneficiario);
      benefeciaryRelation.Save();
    }

    private string GenerateContractNumber() {
      StringBuilder contractNumber = new StringBuilder("PF");

      switch (this.ContractType.Name) {
        case "Optimo" :
          contractNumber.Append("OP");
          break;
        case "Escencial":
          contractNumber.Append("ES");
          break;
        case "Plus":
          contractNumber.Append("PL");
          break; 
      }

      Random rand = new Random();
      int number = rand.Next(10000);

      contractNumber.Append("-");
      contractNumber.Append(number);

      char randomChar = (char) rand.Next('a', 'z');

      contractNumber.Append("-");
      contractNumber.Append(randomChar.ToString().ToUpper());

      return contractNumber.ToString();      
    }

    #endregion

  } // class Contract

} // Empiria.Insurtech.Policies.Domain