﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExportarGLPI {
    using System;
    
    
    /// <summary>
    ///   Uma classe de recurso de tipo de alta segurança, para pesquisar cadeias de caracteres localizadas etc.
    /// </summary>
    // Essa classe foi gerada automaticamente pela classe StronglyTypedResourceBuilder
    // através de uma ferramenta como ResGen ou Visual Studio.
    // Para adicionar ou remover um associado, edite o arquivo .ResX e execute ResGen novamente
    // com a opção /str, ou recrie o projeto do VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SQL {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SQL() {
        }
        
        /// <summary>
        ///   Retorna a instância de ResourceManager armazenada em cache usada por essa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ExportarGLPI.SQL", typeof(SQL).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Substitui a propriedade CurrentUICulture do thread atual para todas as
        ///   pesquisas de recursos que usam essa classe de recurso de tipo de alta segurança.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a INSERT INTO TB_CRM (NUM_CRM, NOM_MEDICO)
        ///VALUES(@NUM_CRM, @NOM_MEDICO).
        /// </summary>
        internal static string InsertCrm {
            get {
                return ResourceManager.GetString("InsertCrm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT * FROM TB_CRM WHERE NUM_CRM = @NUM_CRM.
        /// </summary>
        internal static string SelectCrm {
            get {
                return ResourceManager.GetString("SelectCrm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT COD_CHAVE_ACESSO
        ///FROM TB_VENDA
        ///WHERE SUBSTRING(CAST(REPLACE(CAST(TXT_VENDA_XML AS NVARCHAR(MAX)),&apos;utf-8&apos;,&apos;utf-16&apos;) AS VARCHAR(MAX)),0,9) &lt;&gt; &apos;&lt;nfeProc&apos;
        ///AND TIP_STATUS IN (&apos;EF&apos;, &apos;AN&apos;)
        ///AND IND_ORIGEM_CUPOM = &apos;NCR&apos;
        ///AND DAT_MOVIMENTO = CAST(GETDATE() -1 AS DATE).
        /// </summary>
        internal static string SelectXmlAnd {
            get {
                return ResourceManager.GetString("SelectXmlAnd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT CHAVEACESSO, CAST(REPLACE(CAST(xml AS NVARCHAR(MAX)),&apos;utf-8&apos;,&apos;utf-16&apos;) AS XML) AS XML, CAST(REPLACE(CAST(xmlCanc AS NVARCHAR(MAX)),&apos;utf-8&apos;,&apos;utf-16&apos;) AS XML) AS XML_CA FROM siacnfe..NFNFE
        ///WHERE CHAVEACESSO IN 
        ///(
        ///&apos;33220328763118003963650070000124969241781670&apos;,
        ///&apos;33220328763118004420650060000132941809139852&apos;,
        ///&apos;33220328763118004420650070000187111504995546&apos;,
        ///&apos;33220328763118002053650120000182731930086854&apos;,
        ///&apos;33220328763118000190651490000076361351376050&apos;,
        ///&apos;33220328763118002053650140000163431775661820&apos; [o restante da cadeia de caracteres foi truncado]&quot;;.
        /// </summary>
        internal static string SelectXmlNcr {
            get {
                return ResourceManager.GetString("SelectXmlNcr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a UPDATE TB_CRM
        ///	SET NOM_MEDICO = @NOM_MEDICO
        ///WHERE NUM_CRM = @NUM_CRM.
        /// </summary>
        internal static string UpdateCrm {
            get {
                return ResourceManager.GetString("UpdateCrm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a UPDATE V
        ///   SET TXT_VENDA_XML = CAST(REPLACE(CAST(@TXT_VENDA_XML AS NVARCHAR(MAX)),&apos;utf-8&apos;,&apos;utf-16&apos;) AS XML),
        ///	   TXT_CANCELAMENTO_XML = CAST(REPLACE(CAST(@TXT_CANCELAMENTO_XML AS NVARCHAR(MAX)),&apos;utf-8&apos;,&apos;utf-16&apos;) AS XML)
        ///  FROM NOSSADRG_VENDA.DBO.TB_VENDA (NOLOCK) V
        /// WHERE COD_CHAVE_ACESSO = @COD_CHAVE_ACESSO.
        /// </summary>
        internal static string UpdateXmlAnd {
            get {
                return ResourceManager.GetString("UpdateXmlAnd", resourceCulture);
            }
        }
    }
}
