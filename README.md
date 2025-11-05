# MscrmTools.RelationshipMappingEditor
An XrmToolBox tool to manage relationship attributes mapping

## Why this tool?
When you need to edit the column mapping for a relationship, you have to use classic customization editor, which can take time to load. It also allows only to create one column mapping per opened page.
This tool brings these useful features:
- Column search
- Target column filtering depending on source column selected
- Stay on the same screen to add multiple mapping

## How to use it
Connect to a dataverse environment
### Load tables
You can load tables from a specific solution or all tables in the connected environment
<img width="1271" height="180" alt="image" src="https://github.com/user-attachments/assets/4201eb71-fa43-4cbd-939b-b6c3cfe5bbba" />

### Select the parent table
When searching for a relationship attributes mapping, always select the parent table in the relationship. When selected, a new list appears with the child tables available for this parent table
<img width="1269" height="357" alt="image" src="https://github.com/user-attachments/assets/a4effa9d-ece5-4719-92e5-57c35997877d" />

### Select the child table
Columns mapping is the same for all relationship involving the same tables. Select the child table to display the existing mappings, and the columns from parent and child tables.
<img width="1265" height="269" alt="image" src="https://github.com/user-attachments/assets/a2a2c910-af73-46e8-b799-69c5a67a79f4" />

### Select a source table column
When selecting a source column, the possible target columns are displayed, following [these rules](https://learn.microsoft.com/en-us/power-apps/maker/data-platform/map-entity-fields#kinds-of-data-and-rules-for-mapping)
<img width="1268" height="557" alt="image" src="https://github.com/user-attachments/assets/5dc3666f-d23e-4694-af38-bd11fb0ac421" />


### Add a mapping
Select a target column and click on Add mapping button.
<img width="1266" height="646" alt="image" src="https://github.com/user-attachments/assets/fe10f98f-da9d-4d2e-b20b-c3a924cc10a5" />

You can also click on the button **Auto map**. This will shows the columns present in both source and target tables with the same logical name. If you confirm, a mapping will be created for each of the presented columns.
<img width="1268" height="647" alt="image" src="https://github.com/user-attachments/assets/158c2a50-2849-494f-a813-6ad560b9459d" />

### Delete a mapping
Select one or multiple mapping and click on button **Delete mapping**. This action is available only if selected mappings are not system or managed ones.
<img width="1268" height="649" alt="image" src="https://github.com/user-attachments/assets/4f53b510-ab2e-428a-b8c6-495c06750efb" />
