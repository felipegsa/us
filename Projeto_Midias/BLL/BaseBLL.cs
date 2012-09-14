using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    public class BaseBLL<T>
    {
        /*
         * Class Super da BLL genérica para qualquer tipo de objeto Model. Função da classe é instanciar o objeto BLL
         */

        #region "Atributos"

            private T _model;

        #endregion

        #region "Construtores"

            public BaseBLL() {}

            public BaseBLL(T Model)
            {
                this._model = Model;
            }

        #endregion

        #region "Propriedades"

            public T Model
            {
                get { return this._model; }
                set { this._model = value; }
            }

        #endregion
    }
}
