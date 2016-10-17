using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorK8101
{
    class Controller
    {
        #region Fields
        private FrmView _view;
        #endregion

        #region Properties
        public FrmView View
        {
            get { return _view; }
            set { _view = value; }
        }
        #endregion

        #region Contructor
        public Controller(FrmView view)
        {
            this.View = view;
        }
        #endregion


    }
}
