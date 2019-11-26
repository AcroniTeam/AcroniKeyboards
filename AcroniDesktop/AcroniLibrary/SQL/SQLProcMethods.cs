using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using AcroniLibrary.FileInfo;
using System.Data;

namespace AcroniLibrary.SQL
{
    public class SQLProcMethods
    {
        private static byte[] image;

        #region Procedures Específicas
        public static byte[] SELECT_UserImage()
        {
            return (byte[])SELECT($"EXEC usp_selUserImage @usuario='{SQLConnection.nome_usuario}'")[0];
        }

        public static List<Object> SELECT_IdColecao(String nick_colecao, int id_cliente)
        {
            return SELECT($"EXEC usp_selIdColecao @nick_colecao='{nick_colecao}',@id_cliente={id_cliente}");
        }

        public static List<Object> SELECT_UserPartialInfo(String usuario)
        {
            return SELECT($"EXEC usp_selUserInfo @usuario='{usuario}'");
        }

        public static List<Object> SELECT_Info_UserCad(String usuario, String email)
        {
            return SELECT($"EXEC usp_selCadUserInfo @usuario='{usuario}',@email='{email}'");
        }

        public static List<object> SELECT_Info_MinhaConta()
        {
            return SELECT($"EXEC usp_selMinhaContaInfo @userId={Share.User.ID}");
        }

        public static DataTable SELECT_NicknameTelcadoFrom(int id_cliente)
        {
            return SelectTable($"EXEC usp_selNicknameTecladoCustomizado @id_cliente={id_cliente}");
        }

        public static DataTable SELECT_NicknameColecaoFrom(int id_cliente)
        {
            return SelectTable($"EXEC usp_selNickColecao @id_cliente={id_cliente}");
        }

        public static int UPDATE_QtdeTeclados()
        {
            return DoInsertUpdateDelete($"EXEC usp_updQtdeTeclados @QTDE={Share.User.KeyboardQuantity},@id={Share.User.ID}");
        }

        public static int UPDATE_Info_MinhaConta(String coluna, String valor, int id)
        {
            return DoInsertUpdateDelete($"EXEC usp_updMinhaContaInfo @column='{coluna}',@value='{valor}',@id={id}");
        }

        public static int UPDATE_Senha(String senha, String email)
        {
            return DoInsertUpdateDelete($"EXEC usp_updSenhaUsuario @nova_senha='{senha}',@email='{email}'");
        }

        public static int UPDATE_Colecao(String nick_colecao, int id_cliente, int id_colecao)
        {
            return DoInsertUpdateDelete($"EXEC usp_updColecao @nick_colecao='{nick_colecao}',@id_cliente={id_cliente},@id_colecao={id_colecao}");
        }

        public static int UPDATE_ImgCliente(byte[] img, int id_cliente)
        {
            image = img;
            return DoInsertUpdateDelete($"EXEC usp_updImagemCliente @img=@newimage,@id_cliente={id_cliente}");
        }

        public static int UPDATE_ImgTecladoCustomizado(byte[] img, int id_cliente, String nickname_teclado)
        {
            image = img;
            return DoInsertUpdateDelete($"EXEC usp_updImagemTecladoCustomizado @nova_imagem=@newimage, @id_cliente={id_cliente},@nickname_teclado='{nickname_teclado}'");
        }

        public static int UPDATE_PriceTecladoCustomizado(float preco, int id_cliente, String nickname_teclado)
        {
            return DoInsertUpdateDelete($"EXEC usp_updPrecoTecladoCustomizado @preco = {preco.ToString().Replace(",",".")}, @id_cliente={id_cliente},@nickname_teclado='{nickname_teclado}'");
        }

        public static int UPDATE_ImgColecao(byte[] img, int id_cliente, String nickname_colecao)
        {
            image = img;
            return DoInsertUpdateDelete($"EXEC usp_updImagemColecao @nova_img=@newimage,@id_cliente={id_cliente},@nick_colecao='{nickname_colecao}'");
        }

        public static int INSERT_CadastroCliente(String nome, String usuario, String senha, String email, String cpf)
        {
            String SQLCommand = $"EXEC usp_insCadTblCliente @nome='{nome.Replace(' ', '-')}',@usuario='{usuario}',@senha='{senha}',@email='{email}',@cpf='{cpf}'";
            int ret = 0;
            SqlConnection newConn = new SqlConnection(SQLConnection.nome_conexao);
            try
            {
                newConn.Open();
            }
            catch (Exception)
            {
                newConn.Close();
                newConn.Dispose();
                newConn = new SqlConnection(SQLConnection.nome_conexao.Replace("\\SQLEXPRESS", ""));
                newConn.Open();
            }
            finally
            {
                using (SqlCommand newComm = new SqlCommand(SQLCommand, newConn))
                {
                    String[] parameters = SQLCommand.Split(new char[] { ' ', ',', '=' });
                    for (int i = 2; i < parameters.Length - 1; i += 2)
                    {
                        newComm.Parameters.AddWithValue(parameters[i], parameters[i + 1]);
                    }
                    ret = newComm.ExecuteNonQuery();
                }
                newConn.Close();
                newConn.Dispose();
            }
            return ret;
        }

        public static int INSERT_TecladoCustomizado(int id_cli, byte[] img, String nickname_colecao, String nickname_teclado, Double preco)
        {
            image = img;
            return DoInsertUpdateDelete($"EXEC usp_insTecladoCustomizado @id_cli={id_cli},@nickname_colecao='{nickname_colecao}',@nickname_teclado='{nickname_teclado}',@preco={preco.ToString().Replace(",",".")},@imagem_teclado=@newimage");
        }

        public static int INSERT_Colecao(int id_cliente, String nickname_colecao, byte[] img)
        {
            image = img;
            return DoInsertUpdateDelete($"EXEC usp_insColecao @id_cliente={Share.User.ID},@nickname_colecao='{nickname_colecao}',@img=@newimage");
        }
        public static int DELETE_TecladosCustomizadosFrom(int id_cliente)
        {
            return DoInsertUpdateDelete($"EXEC usp_delTecladoCustomizado @id={id_cliente}");
        }

        public static int DELETE_ColecaoFrom(int id_cliente, String nick_colecao)
        {
            return DoInsertUpdateDelete($"EXEC usp_delColecao @id_cliente={id_cliente},@nick_colecao='{nick_colecao}'");
        }

        public static int DELETE_TecladoCustomizadoFromName(int id_cliente, String nickname)
        {
            return DoInsertUpdateDelete($"EXEC usp_delTecladoCustomizadoFromName @id_cliente={id_cliente},@nickname='{nickname}'");
        }

        #endregion

        #region Métodos gerais para Procedures

        private static List<object> SELECT(string SelectCommand)
        {
            List<object> ret = new List<object> { };
            SqlConnection newConn = new SqlConnection(SQLConnection.nome_conexao);
            try
            {
                newConn.Open();
            }
            catch (Exception)
            {
                newConn.Close();
                newConn.Dispose();
                newConn = new SqlConnection(SQLConnection.nome_conexao.Replace("\\SQLEXPRESS", ""));
                newConn.Open();
            }
            finally
            {
                using (SqlCommand newComm = new SqlCommand(SelectCommand, newConn))
                {
                    String[] parameters = SelectCommand.Split(new char[] { ' ', ',' });
                    for (int i = 2; i < parameters.Length - 1; i += 2)
                    {
                        String[] eq = parameters[i].Split('=');
                        newComm.Parameters.AddWithValue(eq[0], eq[1]);
                    }
                    using (SqlDataReader reader = newComm.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            { ret.Add(reader[i]); }
                        }
                    }
                }
                newConn.Close();
                newConn.Dispose();
            }
            return ret;
        }

        private static DataTable SelectTable(String SelectCommand)
        {
            DataTable ret = new DataTable();
            SqlConnection newConn = new SqlConnection(SQLConnection.nome_conexao);
            try
            {
                newConn.Open();
            }
            catch (Exception)
            {
                newConn.Close();
                newConn.Dispose();
                newConn = new SqlConnection(SQLConnection.nome_conexao.Replace("\\SQLEXPRESS", ""));
                newConn.Open();
            }
            finally
            {
                using (SqlCommand newComm = new SqlCommand(SelectCommand, newConn))
                {
                    String[] parameters = SelectCommand.Split(new char[] { ' ', ',' });
                    for (int i = 2; i < parameters.Length - 1; i += 2)
                    {
                        String[] eq = parameters[i].Split('=');
                        newComm.Parameters.AddWithValue(eq[0], (eq[0].Contains("nome") ? eq[1].Replace('-', ' ') : eq[1]));
                    }
                    using (SqlDataAdapter reader = new SqlDataAdapter(newComm))
                    {
                        reader.Fill(ret);
                    }
                }
                newConn.Close();
                newConn.Dispose();
            }
            return ret;
        }

        private static int DoInsertUpdateDelete(String SQLCommand)
        {
            int ret = 0;
            SqlConnection newConn = new SqlConnection(SQLConnection.nome_conexao);
            try
            {
                newConn.Open();
            }
            catch (Exception)
            {
                newConn.Close();
                newConn.Dispose();
                newConn = new SqlConnection(SQLConnection.nome_conexao.Replace("\\SQLEXPRESS", ""));
                newConn.Open();
            }
            finally
            {
                using (SqlCommand newComm = new SqlCommand(SQLCommand, newConn))
                {
                    String[] parameters = SQLCommand.Split(new char[] { ' ', ',', '=' });
                    for (int i = 2; i < parameters.Length - 1; i += 2)
                    {
                        newComm.Parameters.AddWithValue(parameters[i], parameters[i + 1]);
                    }
                    try
                    {
                        if (newComm.CommandText.Contains("@newimage"))
                        {
                            SqlParameter p = new SqlParameter("@newimage", SqlDbType.Binary);
                            p.Value = image;
                            newComm.Parameters.Add(p);
                        }
                        ret = newComm.ExecuteNonQuery();
                    }
                    catch (Exception e) { MessageBox.Show(e.Message);contTimesTried++; if (contTimesTried < 2) { DoInsertUpdateDelete(SQLCommand); } else contTimesTried = 0;  }

                }
                newConn.Close();
                newConn.Dispose();
            }
            return ret;
        }
        static int contTimesTried = 0;
        #endregion

    }
}
