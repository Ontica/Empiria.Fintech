/* Empiria Insurtech *****************************************************************************************
*                                                                                                            *
*  Module   : Policies Management                          Component : Domain Layer                          *
*  Assembly : Empiria.Insurtech.dll                        Pattern   : Aggregate root                        *
*  Type     : ContractType                                 License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Describes contract type.                                                                       *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;


namespace Empiria.Insurtech.Policies.Domain {

  /// <summary>Describes contract type.</summary>
  public class ContractType : GeneralObject {

    #region Constructors and parsers

    public ContractType() {
      // Required by Empiria Framework.
    }

    static public ContractType Parse(int id) {
      return BaseObject.ParseId<ContractType>(id);
    }

    static public ContractType Parse(string uid) {
      return BaseObject.ParseKey<ContractType>(uid);
    }

    static public FixedList<ContractType> GetList() {
      return GeneralObject.GetList<ContractType>();
    }

    static public ContractType Empty {
      get {
        return BaseObject.ParseEmpty<ContractType>();
      }
    }


    #endregion Constructors and parsers


  }
}