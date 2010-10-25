﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalManager.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="HospitalManagerDB")]
	public partial class PastMedicalHistoryDatabase : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertFamilyCondition(FamilyCondition instance);
    partial void UpdateFamilyCondition(FamilyCondition instance);
    partial void DeleteFamilyCondition(FamilyCondition instance);
    partial void InsertFamilyMember(FamilyMember instance);
    partial void UpdateFamilyMember(FamilyMember instance);
    partial void DeleteFamilyMember(FamilyMember instance);
    partial void InsertPastMedicalHistory(PastMedicalHistory instance);
    partial void UpdatePastMedicalHistory(PastMedicalHistory instance);
    partial void DeletePastMedicalHistory(PastMedicalHistory instance);
    partial void InsertPatientCondition(PatientCondition instance);
    partial void UpdatePatientCondition(PatientCondition instance);
    partial void DeletePatientCondition(PatientCondition instance);
    partial void InsertMedicalCondition(MedicalCondition instance);
    partial void UpdateMedicalCondition(MedicalCondition instance);
    partial void DeleteMedicalCondition(MedicalCondition instance);
    partial void InsertOtherFamilyCondition(OtherFamilyCondition instance);
    partial void UpdateOtherFamilyCondition(OtherFamilyCondition instance);
    partial void DeleteOtherFamilyCondition(OtherFamilyCondition instance);
    partial void InsertOtherPatientCondition(OtherPatientCondition instance);
    partial void UpdateOtherPatientCondition(OtherPatientCondition instance);
    partial void DeleteOtherPatientCondition(OtherPatientCondition instance);
    #endregion
		
		public PastMedicalHistoryDatabase() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["HospitalManagerDBConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PastMedicalHistoryDatabase(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PastMedicalHistoryDatabase(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PastMedicalHistoryDatabase(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PastMedicalHistoryDatabase(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<FamilyCondition> FamilyConditions
		{
			get
			{
				return this.GetTable<FamilyCondition>();
			}
		}
		
		public System.Data.Linq.Table<FamilyMember> FamilyMembers
		{
			get
			{
				return this.GetTable<FamilyMember>();
			}
		}
		
		public System.Data.Linq.Table<PastMedicalHistory> PastMedicalHistories
		{
			get
			{
				return this.GetTable<PastMedicalHistory>();
			}
		}
		
		public System.Data.Linq.Table<PatientCondition> PatientConditions
		{
			get
			{
				return this.GetTable<PatientCondition>();
			}
		}
		
		public System.Data.Linq.Table<MedicalCondition> MedicalConditions
		{
			get
			{
				return this.GetTable<MedicalCondition>();
			}
		}
		
		public System.Data.Linq.Table<OtherFamilyCondition> OtherFamilyConditions
		{
			get
			{
				return this.GetTable<OtherFamilyCondition>();
			}
		}
		
		public System.Data.Linq.Table<OtherPatientCondition> OtherPatientConditions
		{
			get
			{
				return this.GetTable<OtherPatientCondition>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.FamilyConditions")]
	public partial class FamilyCondition : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserID;
		
		private int _FamilyMemberID;
		
		private int _ConditionID;
		
		private EntityRef<FamilyMember> _FamilyMembers;
		
		private EntitySet<MedicalCondition> _MedicalConditions;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnFamilyMemberIDChanging(int value);
    partial void OnFamilyMemberIDChanged();
    partial void OnConditionIDChanging(int value);
    partial void OnConditionIDChanged();
    #endregion
		
		public FamilyCondition()
		{
			this._FamilyMembers = default(EntityRef<FamilyMember>);
			this._MedicalConditions = new EntitySet<MedicalCondition>(new Action<MedicalCondition>(this.attach_MedicalConditions), new Action<MedicalCondition>(this.detach_MedicalConditions));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FamilyMemberID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int FamilyMemberID
		{
			get
			{
				return this._FamilyMemberID;
			}
			set
			{
				if ((this._FamilyMemberID != value))
				{
					this.OnFamilyMemberIDChanging(value);
					this.SendPropertyChanging();
					this._FamilyMemberID = value;
					this.SendPropertyChanged("FamilyMemberID");
					this.OnFamilyMemberIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ConditionID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ConditionID
		{
			get
			{
				return this._ConditionID;
			}
			set
			{
				if ((this._ConditionID != value))
				{
					this.OnConditionIDChanging(value);
					this.SendPropertyChanging();
					this._ConditionID = value;
					this.SendPropertyChanged("ConditionID");
					this.OnConditionIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FamilyCondition_FamilyMember", Storage="_FamilyMembers", ThisKey="FamilyMemberID", OtherKey="FamilyMemberID", IsUnique=true, IsForeignKey=false)]
		public FamilyMember FamilyMembers
		{
			get
			{
				return this._FamilyMembers.Entity;
			}
			set
			{
				FamilyMember previousValue = this._FamilyMembers.Entity;
				if (((previousValue != value) 
							|| (this._FamilyMembers.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._FamilyMembers.Entity = null;
						previousValue.FamilyCondition = null;
					}
					this._FamilyMembers.Entity = value;
					if ((value != null))
					{
						value.FamilyCondition = this;
					}
					this.SendPropertyChanged("FamilyMembers");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FamilyCondition_MedicalCondition", Storage="_MedicalConditions", ThisKey="ConditionID", OtherKey="ConditionID")]
		public EntitySet<MedicalCondition> MedicalConditions
		{
			get
			{
				return this._MedicalConditions;
			}
			set
			{
				this._MedicalConditions.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_MedicalConditions(MedicalCondition entity)
		{
			this.SendPropertyChanging();
			entity.FamilyCondition = this;
		}
		
		private void detach_MedicalConditions(MedicalCondition entity)
		{
			this.SendPropertyChanging();
			entity.FamilyCondition = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.FamilyMembers")]
	public partial class FamilyMember : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _FamilyMemberID;
		
		private string _MemberName;
		
		private EntityRef<FamilyCondition> _FamilyCondition;
		
		private EntityRef<OtherFamilyCondition> _OtherFamilyCondition;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnFamilyMemberIDChanging(int value);
    partial void OnFamilyMemberIDChanged();
    partial void OnMemberNameChanging(string value);
    partial void OnMemberNameChanged();
    #endregion
		
		public FamilyMember()
		{
			this._FamilyCondition = default(EntityRef<FamilyCondition>);
			this._OtherFamilyCondition = default(EntityRef<OtherFamilyCondition>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FamilyMemberID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int FamilyMemberID
		{
			get
			{
				return this._FamilyMemberID;
			}
			set
			{
				if ((this._FamilyMemberID != value))
				{
					if ((this._FamilyCondition.HasLoadedOrAssignedValue || this._OtherFamilyCondition.HasLoadedOrAssignedValue))
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnFamilyMemberIDChanging(value);
					this.SendPropertyChanging();
					this._FamilyMemberID = value;
					this.SendPropertyChanged("FamilyMemberID");
					this.OnFamilyMemberIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MemberName", DbType="NChar(255) NOT NULL", CanBeNull=false)]
		public string MemberName
		{
			get
			{
				return this._MemberName;
			}
			set
			{
				if ((this._MemberName != value))
				{
					this.OnMemberNameChanging(value);
					this.SendPropertyChanging();
					this._MemberName = value;
					this.SendPropertyChanged("MemberName");
					this.OnMemberNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FamilyCondition_FamilyMember", Storage="_FamilyCondition", ThisKey="FamilyMemberID", OtherKey="FamilyMemberID", IsForeignKey=true)]
		public FamilyCondition FamilyCondition
		{
			get
			{
				return this._FamilyCondition.Entity;
			}
			set
			{
				FamilyCondition previousValue = this._FamilyCondition.Entity;
				if (((previousValue != value) 
							|| (this._FamilyCondition.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._FamilyCondition.Entity = null;
						previousValue.FamilyMembers = null;
					}
					this._FamilyCondition.Entity = value;
					if ((value != null))
					{
						value.FamilyMembers = this;
						this._FamilyMemberID = value.FamilyMemberID;
					}
					else
					{
						this._FamilyMemberID = default(int);
					}
					this.SendPropertyChanged("FamilyCondition");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="OtherFamilyCondition1_FamilyMember", Storage="_OtherFamilyCondition", ThisKey="FamilyMemberID", OtherKey="FamilyMemberID", IsForeignKey=true)]
		public OtherFamilyCondition OtherFamilyCondition
		{
			get
			{
				return this._OtherFamilyCondition.Entity;
			}
			set
			{
				OtherFamilyCondition previousValue = this._OtherFamilyCondition.Entity;
				if (((previousValue != value) 
							|| (this._OtherFamilyCondition.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._OtherFamilyCondition.Entity = null;
						previousValue.FamilyMembers = null;
					}
					this._OtherFamilyCondition.Entity = value;
					if ((value != null))
					{
						value.FamilyMembers = this;
						this._FamilyMemberID = value.FamilyMemberID;
					}
					else
					{
						this._FamilyMemberID = default(int);
					}
					this.SendPropertyChanged("OtherFamilyCondition");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PastMedicalHistories")]
	public partial class PastMedicalHistory : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserID;
		
		private System.Nullable<int> _Height;
		
		private System.Nullable<int> _Weight;
		
		private System.Nullable<int> _Age;
		
		private string _Gender;
		
		private string _Ethnicity;
		
		private string _Allergies;
		
		private string _Operations;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnHeightChanging(System.Nullable<int> value);
    partial void OnHeightChanged();
    partial void OnWeightChanging(System.Nullable<int> value);
    partial void OnWeightChanged();
    partial void OnAgeChanging(System.Nullable<int> value);
    partial void OnAgeChanged();
    partial void OnGenderChanging(string value);
    partial void OnGenderChanged();
    partial void OnEthnicityChanging(string value);
    partial void OnEthnicityChanged();
    partial void OnAllergiesChanging(string value);
    partial void OnAllergiesChanged();
    partial void OnOperationsChanging(string value);
    partial void OnOperationsChanged();
    #endregion
		
		public PastMedicalHistory()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true)]
		public int UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Height", DbType="Int NOT NULL")]
		public System.Nullable<int> Height
		{
			get
			{
				return this._Height;
			}
			set
			{
				if ((this._Height != value))
				{
					this.OnHeightChanging(value);
					this.SendPropertyChanging();
					this._Height = value;
					this.SendPropertyChanged("Height");
					this.OnHeightChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Weight", DbType="Int NOT NULL")]
		public System.Nullable<int> Weight
		{
			get
			{
				return this._Weight;
			}
			set
			{
				if ((this._Weight != value))
				{
					this.OnWeightChanging(value);
					this.SendPropertyChanging();
					this._Weight = value;
					this.SendPropertyChanged("Weight");
					this.OnWeightChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Age", DbType="Int NOT NULL")]
		public System.Nullable<int> Age
		{
			get
			{
				return this._Age;
			}
			set
			{
				if ((this._Age != value))
				{
					this.OnAgeChanging(value);
					this.SendPropertyChanging();
					this._Age = value;
					this.SendPropertyChanged("Age");
					this.OnAgeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gender", DbType="Varchar(10) NOT NULL")]
		public string Gender
		{
			get
			{
				return this._Gender;
			}
			set
			{
				if ((this._Gender != value))
				{
					this.OnGenderChanging(value);
					this.SendPropertyChanging();
					this._Gender = value;
					this.SendPropertyChanged("Gender");
					this.OnGenderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ethnicity", DbType="VarChar(50) NOT NULL")]
		public string Ethnicity
		{
			get
			{
				return this._Ethnicity;
			}
			set
			{
				if ((this._Ethnicity != value))
				{
					this.OnEthnicityChanging(value);
					this.SendPropertyChanging();
					this._Ethnicity = value;
					this.SendPropertyChanged("Ethnicity");
					this.OnEthnicityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Allergies", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string Allergies
		{
			get
			{
				return this._Allergies;
			}
			set
			{
				if ((this._Allergies != value))
				{
					this.OnAllergiesChanging(value);
					this.SendPropertyChanging();
					this._Allergies = value;
					this.SendPropertyChanged("Allergies");
					this.OnAllergiesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Operations", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string Operations
		{
			get
			{
				return this._Operations;
			}
			set
			{
				if ((this._Operations != value))
				{
					this.OnOperationsChanging(value);
					this.SendPropertyChanging();
					this._Operations = value;
					this.SendPropertyChanged("Operations");
					this.OnOperationsChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PatientConditions")]
	public partial class PatientCondition : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserID;
		
		private int _ConditionID;
		
		private EntitySet<MedicalCondition> _MedicalConditions;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnConditionIDChanging(int value);
    partial void OnConditionIDChanged();
    #endregion
		
		public PatientCondition()
		{
			this._MedicalConditions = new EntitySet<MedicalCondition>(new Action<MedicalCondition>(this.attach_MedicalConditions), new Action<MedicalCondition>(this.detach_MedicalConditions));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ConditionID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ConditionID
		{
			get
			{
				return this._ConditionID;
			}
			set
			{
				if ((this._ConditionID != value))
				{
					this.OnConditionIDChanging(value);
					this.SendPropertyChanging();
					this._ConditionID = value;
					this.SendPropertyChanged("ConditionID");
					this.OnConditionIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PatientCondition_MedicalCondition", Storage="_MedicalConditions", ThisKey="ConditionID", OtherKey="ConditionID")]
		public EntitySet<MedicalCondition> MedicalConditions
		{
			get
			{
				return this._MedicalConditions;
			}
			set
			{
				this._MedicalConditions.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_MedicalConditions(MedicalCondition entity)
		{
			this.SendPropertyChanging();
			entity.PatientCondition = this;
		}
		
		private void detach_MedicalConditions(MedicalCondition entity)
		{
			this.SendPropertyChanging();
			entity.PatientCondition = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.MedicalConditions")]
	public partial class MedicalCondition : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ConditionID;
		
		private string _ConditionName;
		
		private EntityRef<PatientCondition> _PatientCondition;
		
		private EntityRef<FamilyCondition> _FamilyCondition;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnConditionIDChanging(int value);
    partial void OnConditionIDChanged();
    partial void OnConditionNameChanging(string value);
    partial void OnConditionNameChanged();
    #endregion
		
		public MedicalCondition()
		{
			this._PatientCondition = default(EntityRef<PatientCondition>);
			this._FamilyCondition = default(EntityRef<FamilyCondition>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ConditionID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ConditionID
		{
			get
			{
				return this._ConditionID;
			}
			set
			{
				if ((this._ConditionID != value))
				{
					if ((this._PatientCondition.HasLoadedOrAssignedValue || this._FamilyCondition.HasLoadedOrAssignedValue))
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnConditionIDChanging(value);
					this.SendPropertyChanging();
					this._ConditionID = value;
					this.SendPropertyChanged("ConditionID");
					this.OnConditionIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ConditionName", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string ConditionName
		{
			get
			{
				return this._ConditionName;
			}
			set
			{
				if ((this._ConditionName != value))
				{
					this.OnConditionNameChanging(value);
					this.SendPropertyChanging();
					this._ConditionName = value;
					this.SendPropertyChanged("ConditionName");
					this.OnConditionNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PatientCondition_MedicalCondition", Storage="_PatientCondition", ThisKey="ConditionID", OtherKey="ConditionID", IsForeignKey=true)]
		public PatientCondition PatientCondition
		{
			get
			{
				return this._PatientCondition.Entity;
			}
			set
			{
				PatientCondition previousValue = this._PatientCondition.Entity;
				if (((previousValue != value) 
							|| (this._PatientCondition.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._PatientCondition.Entity = null;
						previousValue.MedicalConditions.Remove(this);
					}
					this._PatientCondition.Entity = value;
					if ((value != null))
					{
						value.MedicalConditions.Add(this);
						this._ConditionID = value.ConditionID;
					}
					else
					{
						this._ConditionID = default(int);
					}
					this.SendPropertyChanged("PatientCondition");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FamilyCondition_MedicalCondition", Storage="_FamilyCondition", ThisKey="ConditionID", OtherKey="ConditionID", IsForeignKey=true)]
		public FamilyCondition FamilyCondition
		{
			get
			{
				return this._FamilyCondition.Entity;
			}
			set
			{
				FamilyCondition previousValue = this._FamilyCondition.Entity;
				if (((previousValue != value) 
							|| (this._FamilyCondition.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._FamilyCondition.Entity = null;
						previousValue.MedicalConditions.Remove(this);
					}
					this._FamilyCondition.Entity = value;
					if ((value != null))
					{
						value.MedicalConditions.Add(this);
						this._ConditionID = value.ConditionID;
					}
					else
					{
						this._ConditionID = default(int);
					}
					this.SendPropertyChanged("FamilyCondition");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.OtherFamilyConditions")]
	public partial class OtherFamilyCondition : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _OtherConditionID;
		
		private int _UserID;
		
		private int _FamilyMemberID;
		
		private string _Condition;
		
		private EntityRef<FamilyMember> _FamilyMembers;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnOtherConditionIDChanging(int value);
    partial void OnOtherConditionIDChanged();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnFamilyMemberIDChanging(int value);
    partial void OnFamilyMemberIDChanged();
    partial void OnConditionChanging(string value);
    partial void OnConditionChanged();
    #endregion
		
		public OtherFamilyCondition()
		{
			this._FamilyMembers = default(EntityRef<FamilyMember>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OtherConditionID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int OtherConditionID
		{
			get
			{
				return this._OtherConditionID;
			}
			set
			{
				if ((this._OtherConditionID != value))
				{
					this.OnOtherConditionIDChanging(value);
					this.SendPropertyChanging();
					this._OtherConditionID = value;
					this.SendPropertyChanged("OtherConditionID");
					this.OnOtherConditionIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="Int NOT NULL")]
		public int UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FamilyMemberID", DbType="Int NOT NULL")]
		public int FamilyMemberID
		{
			get
			{
				return this._FamilyMemberID;
			}
			set
			{
				if ((this._FamilyMemberID != value))
				{
					this.OnFamilyMemberIDChanging(value);
					this.SendPropertyChanging();
					this._FamilyMemberID = value;
					this.SendPropertyChanged("FamilyMemberID");
					this.OnFamilyMemberIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Condition", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Condition
		{
			get
			{
				return this._Condition;
			}
			set
			{
				if ((this._Condition != value))
				{
					this.OnConditionChanging(value);
					this.SendPropertyChanging();
					this._Condition = value;
					this.SendPropertyChanged("Condition");
					this.OnConditionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="OtherFamilyCondition1_FamilyMember", Storage="_FamilyMembers", ThisKey="FamilyMemberID", OtherKey="FamilyMemberID", IsUnique=true, IsForeignKey=false)]
		public FamilyMember FamilyMembers
		{
			get
			{
				return this._FamilyMembers.Entity;
			}
			set
			{
				FamilyMember previousValue = this._FamilyMembers.Entity;
				if (((previousValue != value) 
							|| (this._FamilyMembers.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._FamilyMembers.Entity = null;
						previousValue.OtherFamilyCondition = null;
					}
					this._FamilyMembers.Entity = value;
					if ((value != null))
					{
						value.OtherFamilyCondition = this;
					}
					this.SendPropertyChanged("FamilyMembers");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.OtherPatientConditions")]
	public partial class OtherPatientCondition : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _OtherConditionID;
		
		private int _UserID;
		
		private string _Condition;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnOtherConditionIDChanging(int value);
    partial void OnOtherConditionIDChanged();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnConditionChanging(string value);
    partial void OnConditionChanged();
    #endregion
		
		public OtherPatientCondition()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OtherConditionID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int OtherConditionID
		{
			get
			{
				return this._OtherConditionID;
			}
			set
			{
				if ((this._OtherConditionID != value))
				{
					this.OnOtherConditionIDChanging(value);
					this.SendPropertyChanging();
					this._OtherConditionID = value;
					this.SendPropertyChanged("OtherConditionID");
					this.OnOtherConditionIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="Int NOT NULL")]
		public int UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Condition", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Condition
		{
			get
			{
				return this._Condition;
			}
			set
			{
				if ((this._Condition != value))
				{
					this.OnConditionChanging(value);
					this.SendPropertyChanging();
					this._Condition = value;
					this.SendPropertyChanged("Condition");
					this.OnConditionChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591