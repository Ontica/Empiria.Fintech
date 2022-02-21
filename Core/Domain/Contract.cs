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

  /// <summary>Enumerates the different contract types.</summary>
  public enum ContractType {

    Escencial = 1,

    Optimo = 2,

    Plus = 3

  }  // ContractType

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

    #endregion Constructors and parsers

    #region Public properties

    public int ContractTrackId {
      get;
      private set;
    }

    public string ContractTrackUID {
      get;
      private set;
    }

    public int ContractId {
      get;
      private set;
    }

    public ContractType ContractTypeId {
      get;
      private set;
    }

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

    public string ContractKeywords {
      get;
      private set;
    }

    public int ModifiedById {
      get;
      private set;
    }

    public char ContractStatus {
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

    public string ContractTrackDIF {
      get;
      private set;
    }


    #endregion Public properties

    #region Methods

    internal void Save() {   
      ContractData.Write(this);  
    }

    #endregion Methods

    #region Private methods

    private void Create(ContractFields fields) {
      this.ContractTrackId = ContractData.GetContractTrackId();
      this.ContractTrackUID = Guid.NewGuid().ToString();
      this.ContractId = ContractData.GetContractId();
      this.ContractNo = GenerateContractNumber();
      this.ContractKeywords = "";
      this.ModifiedById = -1;
      this.ContractStatus = 'C';
      this.StartDate = DateTime.Today;
      this.EndDate = ExecutionServer.DateMaxValue;
      this.ContractTrackDIF = "";
      this.ContractTypeId = (ContractType) Enum.Parse(typeof(ContractType), fields.ContractType);

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

      switch (this.ContractTypeId) {
        case ContractType.Optimo:
          contractNumber.Append("OP");
          break;
        case ContractType.Escencial:
          contractNumber.Append("ES");
          break;
        case ContractType.Plus:
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