﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Text;
using AcroniLibrary.FileInfo;
using System.Data;

namespace AcroniLibrary.SQL
{
    public class SQLProcMethods
    {

        public static void createProceduresSelect()
        {
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
                foreach (String s in File.ReadAllText($@"{Application.StartupPath}/Procedures/SELECT_PROCEDURES.sql", Encoding.UTF8).Split(new String[] { "GO" }, StringSplitOptions.None))
                {
                    try
                    {
                        using (SqlCommand comm = new SqlCommand(s, newConn))
                        {
                            comm.ExecuteNonQuery();
                        }
                    }catch (Exception)
                    {
                    }
                }
                newConn.Close();
                newConn.Dispose();
            }
        }

        #region Procedures Específicas

        public static byte[] SELECT_UserImage()
        {
            return (byte[])SELECT($"EXEC usp_selUserImage @usuario='{SQLConnection.nome_usuario}'")[0];
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

        public static int UPDATE_Colecao(String nick_colecao, int id_cliente)
        {
            return DoInsertUpdateDelete($"EXEC usp_updColecao @nick_colecao='{nick_colecao}',@id_cliente={id_cliente}");
        }

        public static int UPDATE_ImgCliente(byte[] img, int id_cliente)
        {
            return DoInsertUpdateDelete($"EXEC usp_updImagemCliente @img={img},@id_cliente={id_cliente}");
        }

        public static int UPDATE_ImgTecladoCustomizado(byte[] img, int id_cliente, String nickname_teclado)
        {
            return DoInsertUpdateDelete($"EXEC usp_updImagemTecladoCustomizado @nova_imagem={img},@id_cliente={id_cliente},@nickname_teclado='{nickname_teclado}'");
        }

        public static int UPDATE_ImgColecao(byte[] img, int id_cliente, String nickname_colecao)
        {
            return DoInsertUpdateDelete($"EXEC usp_updImagemColecao @nova_img={img},@id_cliente={id_cliente},@nick_colecao='{nickname_colecao}'");
        }

        public static int INSERT_CadastroCliente(String nome, String usuario, String senha, String email, String cpf)        {
            String SQLCommand = $"EXEC usp_insCadTblCliente @nome='{nome.Replace(' ','-')}',@usuario='{usuario}',@senha='{senha}',@email='{email}',@cpf='{cpf}'";
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
                        newComm.Parameters.AddWithValue(parameters[i], parameters[i+1]);
                    }
                    ret = newComm.ExecuteNonQuery();
                }
                newConn.Close();
                newConn.Dispose();
            }
            return ret;
        }

        public static int INSERT_TecladoCustomizado(int id_cli, byte[] img, String nickname_colecao, String nickname_teclado,String preco)
        {
            return DoInsertUpdateDelete($"EXEC usp_insTecladoCustomizado @id_cli={id_cli},@imagem_teclado={img},@nickname_colecao='{nickname_colecao}',@nickname_teclado='{nickname_teclado}',@preco='{preco}'");
        }

        public static int INSERT_Colecao(int id_cliente, String nickname_colecao, byte[] img)
        {
            return DoInsertUpdateDelete($"EXEC usp_insColecao @id_cliente={Share.User.ID},@nickname_colecao='{nickname_colecao}',@img={img}");
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
                    String[] parameters = SelectCommand.Split(new char[] {' ',','});
                    for (int i = 2; i < parameters.Length - 1; i+=2)
                    {
                        String[] eq = parameters[i].Split('=');
                        newComm.Parameters.AddWithValue(eq[0],eq[1]);
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
                        newComm.Parameters.AddWithValue(eq[0], (eq[0].Contains("nome")?eq[1].Replace('-',' '):eq[1]));
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
                    String[] parameters = SQLCommand.Split(new char[] { ' ', ',', '='});
                    for (int i = 2; i < parameters.Length - 1; i += 2)
                    {
                        newComm.Parameters.AddWithValue(parameters[i], parameters[i+1]);
                    }
                    ret = newComm.ExecuteNonQuery();
                }
                newConn.Close();
                newConn.Dispose();
            }
            return ret;
        }
        #endregion
    }
}
