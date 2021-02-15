﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.locafest.Infra.Data.Configuration
{
    public class TipoParametro
    {
        public static DbType Inteiro { get { return DbType.Int32; } }
        public static DbType InteiroCurto { get { return DbType.Int16; } }
        public static DbType InteiroLongo { get { return DbType.Int64; } }
        public static DbType StringComTamanhoFixo { get { return DbType.AnsiStringFixedLength; } }
        public static DbType StringComTamanhoVariavel { get { return DbType.AnsiString; } }
        public static DbType DataETempo { get { return DbType.DateTime; } }
        public static DbType Boleano { get { return DbType.Boolean; } }
        public static DbType Double { get { return DbType.Double; } }
        public static DbType Guid { get { return DbType.Guid; } }
    }
}
