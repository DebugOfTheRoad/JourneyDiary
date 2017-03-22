using System;
using SchemaExplorer;
using System.Data;
using CodeSmith.Engine;
using System.Text.RegularExpressions;

public class BaseTemplate:CodeTemplate
{
	public string CSharpType(ColumnSchema column)  
{  
     if (column.Name.EndsWith("TypeCode")) return column.Name;  
     switch (column.DataType)  
     {  
      case DbType.AnsiString:  
      case DbType.String:  
      case DbType.StringFixedLength:  
      case DbType.AnsiStringFixedLength: return "string";  
      
      case DbType.VarNumeric:  
      case DbType.Currency:  
      case DbType.Decimal: return "decimal";  
      case DbType.Binary: return "byte[]";  
      case DbType.Boolean: return "bool";  
      case DbType.Byte: return "byte";  
      case DbType.Date: 
      case DbType.DateTime: 
      {
           if(column.AllowDBNull)
            {
                
                 return "DateTime?";
            }
            else
            {
                 return "DateTime";
            }
      }
      case DbType.Double: return "double";  
      case DbType.Guid: return "Guid";  
      case DbType.Int16: return "short";  
      case DbType.Int32:
         {
             
              if(column.AllowDBNull)
            {
                
                 return "int?";
            }
            else
            {
                 return "int";
            }
        
         }
      case DbType.Int64: 
         {
              if(column.AllowDBNull)
            {
                
                 return "long?";
            }
            else
            {
                 return "long";
            }
         }
      case DbType.Object: return "object";  
      case DbType.SByte: return "sbyte";  
      case DbType.Single: {
             if(column.AllowDBNull)
            {
                
                 return "float?";
            }
            else
            {
                 return "float";
            }
      }
      case DbType.Time: return "TimeSpan";  
      case DbType.UInt16: return "ushort";  
      case DbType.UInt32: return "uint";  
      case DbType.UInt64: 
         {
               if(column.AllowDBNull)
            {
                
                 return "ulong?";
            }
            else
            {
                 return "ulong";
            }
         }
      default:  
      {  
       return "__UNKNOWN__" + column.NativeType;  
      }  
     
      
    }  
}  

    public string GetPrimaryKeyName(TableSchema tableSchema)
	{
		return tableSchema.PrimaryKey.MemberColumns[0].Name;
	}
}