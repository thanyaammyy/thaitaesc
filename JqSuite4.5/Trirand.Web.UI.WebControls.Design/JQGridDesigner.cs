using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Security.Permissions;
using System.Web;
using System.Web.UI.Design;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;
namespace Trirand.Web.UI.WebControls.Design
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQGridDesigner : DataBoundControlDesigner
	{
		public override string GetDesignTimeHtml()
		{
			return base.CreatePlaceHolderDesignTimeHtml();
		}
		protected override void OnSchemaRefreshed()
		{
			if (!base.InTemplateMode)
			{
				Cursor current = Cursor.Current;
				try
				{
					Cursor.Current = Cursors.WaitCursor;
					ControlDesigner.InvokeTransactedChange(base.Component, new TransactedChangeCallback(this.SchemaRefreshedCallback), null, "Refresh Schema");
					this.UpdateDesignTimeHtml();
				}
				finally
				{
					Cursor.Current = current;
				}
			}
		}
		private bool SchemaRefreshedCallback(object context)
		{
			IDataSourceViewSchema dataSourceSchema = this.GetDataSourceSchema();
			if (base.DataSourceID.Length > 0 && dataSourceSchema != null)
			{
				this.AddKeysAndBoundFields(dataSourceSchema);
			}
			return true;
		}
		private IDataSourceViewSchema GetDataSourceSchema()
		{
			DesignerDataSourceView designerView = base.DesignerView;
			if (designerView != null)
			{
				try
				{
					return designerView.Schema;
				}
				catch (Exception)
				{
					IComponentDesignerDebugService componentDesignerDebugService = (IComponentDesignerDebugService)base.Component.Site.GetService(typeof(IComponentDesignerDebugService));
					if (componentDesignerDebugService != null)
					{
						componentDesignerDebugService.Fail("DataSource_DebugService_FailedCall");
					}
				}
			}
			return null;
		}
		private void AddKeysAndBoundFields(IDataSourceViewSchema schema)
		{
			JQGridColumnCollection columns = ((JQGrid)base.Component).Columns;
			try
			{
				columns.Clear();
			}
			catch (Exception)
			{
			}
			if (schema != null)
			{
				IDataSourceFieldSchema[] fields = schema.GetFields();
				if (fields != null && fields.Length > 0)
				{
					new ArrayList();
					IDataSourceFieldSchema[] array = fields;
					for (int i = 0; i < array.Length; i++)
					{
						IDataSourceFieldSchema dataSourceFieldSchema = array[i];
						if (((JQGrid)base.Component).IsBindableType(dataSourceFieldSchema.DataType))
						{
							JQGridColumn jQGridColumn;
							if (dataSourceFieldSchema.DataType == typeof(bool) || dataSourceFieldSchema.DataType == typeof(bool?))
							{
								jQGridColumn = new JQGridColumn();
							}
							else
							{
								jQGridColumn = new JQGridColumn();
							}
							string name = dataSourceFieldSchema.Name;
							jQGridColumn.DataField = name;
							jQGridColumn.PrimaryKey = dataSourceFieldSchema.PrimaryKey;
							columns.Add(jQGridColumn);
						}
					}
				}
			}
		}
	}
}
