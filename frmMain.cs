using WinFormsAppMaster.Interfaces;
using WinFormsAppMaster.Models;

namespace WinFormsAppMaster
{
    public partial class frmMain : Form
    {
        private readonly IDatabase<GangnamguPopulation> _iDatabase;


        public frmMain(IDatabase<GangnamguPopulation> idatabase)
        {
            InitializeComponent();

            this._iDatabase = idatabase;
        }

        private void nightLabel3_Click(object sender, EventArgs e)
        {

        }

        private void btnReadAll_Click(object sender, EventArgs e)
        {
            var datas = this._iDatabase.Get();

            this.dgvDataTable.DataSource = datas;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            var targetId = this.nbxId.Value;

            var data = this._iDatabase.GetDetail(Convert.ToInt16(targetId));

            this.tbxAdministrativeAgency.Text = data.AdministrativeAgency;
            this.nbxTotalPopulation.Value = (long)data.TotalPopulation;
            this.nbxMalePopulation.Value = (long)data.MalePopulation;
            this.nbxFemalePopulation.Value = (long)data.FemalePopulation;
            this.nbxSexRatio.Value = (long)data.SexRatio;
            this.nbxNumberOfHouseHold.Value = (long)data.NumberOfHouseholds;
            this.nbxPeoplePerHousehold.Value = (long)data.NumberOfPeoplePerHousehold;
            this.nbxId.Value = data.Id;

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            GangnamguPopulation gangnamguPopulation = new GangnamguPopulation()
            {
                AdministrativeAgency = this.tbxAdministrativeAgency.Text,
                TotalPopulation = (int)this.nbxTotalPopulation.Value,
                MalePopulation = (int)this.nbxMalePopulation.Value,
                FemalePopulation = (int)this.nbxFemalePopulation.Value,
                SexRatio = (double)this.nbxSexRatio.Value,
                NumberOfHouseholds = (int)this.nbxNumberOfHouseHold.Value,
                NumberOfPeoplePerHousehold = (double)this.nbxPeoplePerHousehold.Value
               
            };

            this._iDatabase.Create(gangnamguPopulation);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var targetId = this.nbxId.Value;

            var data = this._iDatabase.GetDetail(Convert.ToInt16(targetId));

            data.AdministrativeAgency = this.tbxAdministrativeAgency.Text;
            data.FemalePopulation = (int)this.nbxFemalePopulation.Value;
            data.MalePopulation = (int)this.nbxMalePopulation.Value;
            data.NumberOfHouseholds = (int)this.nbxNumberOfHouseHold.Value;
            data.NumberOfPeoplePerHousehold = (double)this.nbxPeoplePerHousehold.Value;
            data.SexRatio = (double)this.nbxSexRatio.Value;
            data.TotalPopulation = (int)this.nbxTotalPopulation.Value;

            this._iDatabase.Update(data);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var targetId = this.nbxId.Value;

            this._iDatabase.Delete((int)targetId);
        }

    }
}
