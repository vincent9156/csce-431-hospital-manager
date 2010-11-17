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
	public partial class BillingDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertBill(Bill instance);
    partial void UpdateBill(Bill instance);
    partial void DeleteBill(Bill instance);
    partial void InsertPrescriptionBill(PrescriptionBill instance);
    partial void UpdatePrescriptionBill(PrescriptionBill instance);
    partial void DeletePrescriptionBill(PrescriptionBill instance);
    partial void InsertCancellationBill(CancellationBill instance);
    partial void UpdateCancellationBill(CancellationBill instance);
    partial void DeleteCancellationBill(CancellationBill instance);
    #endregion
		
		public BillingDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["HospitalManagerDBConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public BillingDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BillingDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BillingDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BillingDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Bill> Bills
		{
			get
			{
				return this.GetTable<Bill>();
			}
		}
		
		public System.Data.Linq.Table<PrescriptionBill> PrescriptionBills
		{
			get
			{
				return this.GetTable<PrescriptionBill>();
			}
		}
		
		public System.Data.Linq.Table<CancellationBill> CancellationBills
		{
			get
			{
				return this.GetTable<CancellationBill>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Bill")]
	public partial class Bill : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BillID;
		
		private float _Amount;
		
		private string _Diagnosis;
		
		private string _ReasonForVisit;
		
		private int _PatientUserID;
		
		private int _DocUserID;
		
		private System.DateTime _BillDate;
		
		private byte _Paid;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBillIDChanging(int value);
    partial void OnBillIDChanged();
    partial void OnAmountChanging(float value);
    partial void OnAmountChanged();
    partial void OnDiagnosisChanging(string value);
    partial void OnDiagnosisChanged();
    partial void OnReasonForVisitChanging(string value);
    partial void OnReasonForVisitChanged();
    partial void OnPatientUserIDChanging(int value);
    partial void OnPatientUserIDChanged();
    partial void OnDocUserIDChanging(int value);
    partial void OnDocUserIDChanged();
    partial void OnBillDateChanging(System.DateTime value);
    partial void OnBillDateChanged();
    partial void OnPaidChanging(byte value);
    partial void OnPaidChanged();
    #endregion
		
		public Bill()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BillID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL", IsPrimaryKey=true, IsDbGenerated=true)]
		public int BillID
		{
			get
			{
				return this._BillID;
			}
			set
			{
				if ((this._BillID != value))
				{
					this.OnBillIDChanging(value);
					this.SendPropertyChanging();
					this._BillID = value;
					this.SendPropertyChanged("BillID");
					this.OnBillIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Amount", DbType="Float NOT NULL")]
		public float Amount
		{
			get
			{
				return this._Amount;
			}
			set
			{
				if ((this._Amount != value))
				{
					this.OnAmountChanging(value);
					this.SendPropertyChanging();
					this._Amount = value;
					this.SendPropertyChanged("Amount");
					this.OnAmountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Diagnosis", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Diagnosis
		{
			get
			{
				return this._Diagnosis;
			}
			set
			{
				if ((this._Diagnosis != value))
				{
					this.OnDiagnosisChanging(value);
					this.SendPropertyChanging();
					this._Diagnosis = value;
					this.SendPropertyChanged("Diagnosis");
					this.OnDiagnosisChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReasonForVisit", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string ReasonForVisit
		{
			get
			{
				return this._ReasonForVisit;
			}
			set
			{
				if ((this._ReasonForVisit != value))
				{
					this.OnReasonForVisitChanging(value);
					this.SendPropertyChanging();
					this._ReasonForVisit = value;
					this.SendPropertyChanged("ReasonForVisit");
					this.OnReasonForVisitChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PatientUserID", DbType="Int NOT NULL")]
		public int PatientUserID
		{
			get
			{
				return this._PatientUserID;
			}
			set
			{
				if ((this._PatientUserID != value))
				{
					this.OnPatientUserIDChanging(value);
					this.SendPropertyChanging();
					this._PatientUserID = value;
					this.SendPropertyChanged("PatientUserID");
					this.OnPatientUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocUserID", DbType="int NOT NULL")]
		public int DocUserID
		{
			get
			{
				return this._DocUserID;
			}
			set
			{
				if ((this._DocUserID != value))
				{
					this.OnDocUserIDChanging(value);
					this.SendPropertyChanging();
					this._DocUserID = value;
					this.SendPropertyChanged("DocUserID");
					this.OnDocUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BillDate", DbType="Date NOT NULL")]
		public System.DateTime BillDate
		{
			get
			{
				return this._BillDate;
			}
			set
			{
				if ((this._BillDate != value))
				{
					this.OnBillDateChanging(value);
					this.SendPropertyChanging();
					this._BillDate = value;
					this.SendPropertyChanged("BillDate");
					this.OnBillDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Paid", DbType="Bit NOT NULL")]
		public byte Paid
		{
			get
			{
				return this._Paid;
			}
			set
			{
				if ((this._Paid != value))
				{
					this.OnPaidChanging(value);
					this.SendPropertyChanging();
					this._Paid = value;
					this.SendPropertyChanged("Paid");
					this.OnPaidChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PrescriptionBill")]
	public partial class PrescriptionBill : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BillID;
		
		private decimal _Amount;
		
		private int _PrescriptionID;
		
		private byte _Paid;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBillIDChanging(int value);
    partial void OnBillIDChanged();
    partial void OnAmountChanging(decimal value);
    partial void OnAmountChanged();
    partial void OnPrescriptionIDChanging(int value);
    partial void OnPrescriptionIDChanged();
    partial void OnPaidChanging(byte value);
    partial void OnPaidChanged();
    #endregion
		
		public PrescriptionBill()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BillID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL", IsPrimaryKey=true, IsDbGenerated=true)]
		public int BillID
		{
			get
			{
				return this._BillID;
			}
			set
			{
				if ((this._BillID != value))
				{
					this.OnBillIDChanging(value);
					this.SendPropertyChanging();
					this._BillID = value;
					this.SendPropertyChanged("BillID");
					this.OnBillIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Amount", DbType="Decimal NOT NULL")]
		public decimal Amount
		{
			get
			{
				return this._Amount;
			}
			set
			{
				if ((this._Amount != value))
				{
					this.OnAmountChanging(value);
					this.SendPropertyChanging();
					this._Amount = value;
					this.SendPropertyChanged("Amount");
					this.OnAmountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PrescriptionID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int PrescriptionID
		{
			get
			{
				return this._PrescriptionID;
			}
			set
			{
				if ((this._PrescriptionID != value))
				{
					this.OnPrescriptionIDChanging(value);
					this.SendPropertyChanging();
					this._PrescriptionID = value;
					this.SendPropertyChanged("PrescriptionID");
					this.OnPrescriptionIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Paid", DbType="Byte NOT NULL")]
		public byte Paid
		{
			get
			{
				return this._Paid;
			}
			set
			{
				if ((this._Paid != value))
				{
					this.OnPaidChanging(value);
					this.SendPropertyChanging();
					this._Paid = value;
					this.SendPropertyChanged("Paid");
					this.OnPaidChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CancellationBill")]
	public partial class CancellationBill : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BillID;
		
		private double _Amount;
		
		private int _UserID;
		
		private int _DoctorID;
		
		private System.DateTime _BillDate;
		
		private System.DateTime _AppDate;
		
		private string _FeeType;
		
		private bool _Paid;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBillIDChanging(int value);
    partial void OnBillIDChanged();
    partial void OnAmountChanging(double value);
    partial void OnAmountChanged();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnDoctorIDChanging(int value);
    partial void OnDoctorIDChanged();
    partial void OnBillDateChanging(System.DateTime value);
    partial void OnBillDateChanged();
    partial void OnAppDateChanging(System.DateTime value);
    partial void OnAppDateChanged();
    partial void OnFeeTypeChanging(string value);
    partial void OnFeeTypeChanged();
    partial void OnPaidChanging(bool value);
    partial void OnPaidChanged();
    #endregion
		
		public CancellationBill()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BillID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int BillID
		{
			get
			{
				return this._BillID;
			}
			set
			{
				if ((this._BillID != value))
				{
					this.OnBillIDChanging(value);
					this.SendPropertyChanging();
					this._BillID = value;
					this.SendPropertyChanged("BillID");
					this.OnBillIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Amount", DbType="Float NOT NULL")]
		public double Amount
		{
			get
			{
				return this._Amount;
			}
			set
			{
				if ((this._Amount != value))
				{
					this.OnAmountChanging(value);
					this.SendPropertyChanging();
					this._Amount = value;
					this.SendPropertyChanged("Amount");
					this.OnAmountChanged();
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DoctorID", DbType="Int NOT NULL")]
		public int DoctorID
		{
			get
			{
				return this._DoctorID;
			}
			set
			{
				if ((this._DoctorID != value))
				{
					this.OnDoctorIDChanging(value);
					this.SendPropertyChanging();
					this._DoctorID = value;
					this.SendPropertyChanged("DoctorID");
					this.OnDoctorIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BillDate", DbType="Date NOT NULL")]
		public System.DateTime BillDate
		{
			get
			{
				return this._BillDate;
			}
			set
			{
				if ((this._BillDate != value))
				{
					this.OnBillDateChanging(value);
					this.SendPropertyChanging();
					this._BillDate = value;
					this.SendPropertyChanged("BillDate");
					this.OnBillDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AppDate", DbType="Date NOT NULL")]
		public System.DateTime AppDate
		{
			get
			{
				return this._AppDate;
			}
			set
			{
				if ((this._AppDate != value))
				{
					this.OnAppDateChanging(value);
					this.SendPropertyChanging();
					this._AppDate = value;
					this.SendPropertyChanged("AppDate");
					this.OnAppDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FeeType", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string FeeType
		{
			get
			{
				return this._FeeType;
			}
			set
			{
				if ((this._FeeType != value))
				{
					this.OnFeeTypeChanging(value);
					this.SendPropertyChanging();
					this._FeeType = value;
					this.SendPropertyChanged("FeeType");
					this.OnFeeTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Paid", DbType="Bit NOT NULL")]
		public bool Paid
		{
			get
			{
				return this._Paid;
			}
			set
			{
				if ((this._Paid != value))
				{
					this.OnPaidChanging(value);
					this.SendPropertyChanging();
					this._Paid = value;
					this.SendPropertyChanged("Paid");
					this.OnPaidChanged();
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
