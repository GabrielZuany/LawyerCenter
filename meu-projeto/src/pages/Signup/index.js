import React, { useState } from "react";
import Input from "../../components/Input";
import Button from "../../components/Button";
import * as C from "./styles";
import { Link, useNavigate } from "react-router-dom";
import useAuth from "../../hooks/useAuth";
import logozinho from "../../img/logozinho.png";
import logo_centro from "../../img/logo-centro.png";

const Signup = () => {
  const [nome, setNome] = useState("");
  const [email, setEmail] = useState("");
  const [cpf, setCPF] = useState("");
  const [cidade, setCidade] = useState("");
  const [senha, setSenha] = useState("");
  const [error, setError] = useState("");
  const [estado, setEstado] = useState("");
  
  const [nomeAdvogado, setNomeAdvogado] = useState("");
  const [emailAdvogado, setEmailAdvogado] = useState("");
  const [cpfAdvogado, setCPFAdvogado] = useState("");
  const [cidadeAdvogado, setCidadeAdvogado] = useState("");
  const [estadoAdvogado, setEstadoAdvogado] = useState("");
  const [idOAB, setID] = useState("");
  const [categoria, setCategoria] = useState("");
  const [idade, setIdade] = useState("");
  const [senhaAdvogado, setSenhaAdvogado] = useState("");
  const [errorAdvogado, setErrorAdvogado] = useState("");

  const handleEstadoChange = (e) => {
    setEstado(e.target.value);
  };
  const handleCategoria = (e) => {
    setCategoria(e.target.value);
  };
  const handleEstadoAdvogadoChange = (e) => {
    setEstadoAdvogado(e.target.value);
  };
  const navigate = useNavigate();

  const { signup } = useAuth();

  const handleSignup = (isAdvogado = false) => {
    let nomeToUse = isAdvogado ? nomeAdvogado : nome;
    let emailToUse = isAdvogado ? emailAdvogado : email;
    let cpfToUse = isAdvogado ? cpfAdvogado : cpf;
    let cidadeToUse = isAdvogado ? cidadeAdvogado : cidade;
    let estadoToUse = isAdvogado ? estadoAdvogado : estado;
    let senhaToUse = isAdvogado ? senhaAdvogado : senha;
    let setErrorFunc = isAdvogado ? setErrorAdvogado : setError;
  
    // Verificação de campos obrigatórios comuns
    if (!nomeToUse || !emailToUse || !cpfToUse || !cidadeToUse || !estadoToUse || !senhaToUse) {
      setErrorFunc("Preencha todos os campos");
      return;
    }
  
    // Verificação de campos adicionais para advogados
    if (isAdvogado) {
      if (!idOAB || !categoria || !idade) {
        setErrorAdvogado("Preencha todos os campos específicos para advogados");
        return;
      }
    }
  
    // Dados adicionais específicos para advogados
    let idOABToUse = isAdvogado ? idOAB : null;
    let categoriaToUse = isAdvogado ? categoria : null;
    let idadeToUse = isAdvogado ? idade : null;
  
    // Chamar a função de signup com os dados apropriados
    const res = signup({
      nome: nomeToUse,
      email: emailToUse,
      cpf: cpfToUse,
      cidade: cidadeToUse,
      estado: estadoToUse,
      senha: senhaToUse,
      idOAB: idOABToUse,
      categoria: categoriaToUse,
      idade: idadeToUse
    });
  
    if (res) {
      setErrorFunc(res);
      return;
    }
  
    alert("Usuário cadastrado com sucesso!");
    navigate("/");
  };
  
  return (
    <>
    <C.Logozinho src = {logozinho} alt="Logozinho" title="Logozinho"/>
    <C.Container>
      <C.Content>
        <h2>É cliente?</h2>
        <Input
          type="nome"
          placeholder="Nome Completo"
          value={nome}
          onChange={(e) => [setNome(e.target.value), setError("")]}
        />
        <Input
          type="email"
          placeholder="Digite seu E-mail"
          value={email}
          onChange={(e) => [setEmail(e.target.value), setError("")]}
        />
        <Input
          type="cpf"
          placeholder="CPF"
          value={cpf}
          onChange={(e) => [setCPF(e.target.value), setError("")]}
        />
        
        <C.Select value={estado} onChange={handleEstadoChange} hasValue={estado !== ""}>
          
          <option value="">Selecione o Estado</option>
          <option value="AC">AC</option>
          <option value="AL">AL</option>
          <option value="AP">AP</option>
          <option value="AM">AM</option>
          <option value="BA">BA</option> 
          <option value="CE">CE</option>
          <option value="DF">DF</option>
          <option value="ES">ES</option>
          <option value="GO">GO</option>
          <option value="MA">MA</option>
          <option value="MT">MT</option>
          <option value="MS">MS</option>
          <option value="MG">MG</option>
          <option value="PA">PA</option>
          <option value="PB">PB</option>
          <option value="PR">PR</option>
          <option value="PE">PE</option>
          <option value="PI">PI</option>
          <option value="RJ">RJ</option>
          <option value="RN">RN</option>
          <option value="RS">RS</option>
          <option value="RO">RO</option>
          <option value="RR">RR</option>
          <option value="SC">SC</option>
          <option value="SP">SP</option>
          <option value="SE">SE</option>
          <option value="TO">TO</option>
        </C.Select>
        
        <Input
          type="cidade"
          placeholder="Insira sua cidade"
          value={cidade}
          onChange={(e) => [setCidade(e.target.value), setError("")]}
        />
        <Input
          type="password"
          placeholder="Digite sua Senha"
          value={senha}
          onChange={(e) => [setSenha(e.target.value), setError("")]}
        />
        <C.labelError>{error}</C.labelError>
        <Button Text="Cadastrar" onClick={() => handleSignup(false)} />
        <C.LabelSignin>
          Já tem uma conta?
          <C.Strong>
            <Link to="/"> Entre</Link>
          </C.Strong>
        </C.LabelSignin>
      </C.Content>
      <C.Logo_centro src = {logo_centro} alt="Logo_centro" title="Logo_centro"/>
      <C.Content>
        <h2>É advogado?</h2>
        <Input
          type="nome"
          placeholder="Nome Completo"
          value={nomeAdvogado}
          onChange={(e) => [setNomeAdvogado(e.target.value), setErrorAdvogado("")]}
        />
        <Input
          type="email"
          placeholder="Digite seu E-mail"
          value={emailAdvogado}
          onChange={(e) => [setEmailAdvogado(e.target.value), setErrorAdvogado("")]}
        />
        <Input
          type="cpf"
          placeholder="CPF"
          value={cpfAdvogado}
          onChange={(e) => [setCPFAdvogado(e.target.value), setErrorAdvogado("")]}
        />
        <C.Select value={estadoAdvogado} onChange={handleEstadoAdvogadoChange} hasValue={estadoAdvogado !== ""}>
          
          <option value="">Selecione o Estado</option>
          <option value="AC">AC</option>
          <option value="AL">AL</option>
          <option value="AP">AP</option>
          <option value="AM">AM</option>
          <option value="BA">BA</option> 
          <option value="CE">CE</option>
          <option value="DF">DF</option>
          <option value="ES">ES</option>
          <option value="GO">GO</option>
          <option value="MA">MA</option>
          <option value="MT">MT</option>
          <option value="MS">MS</option>
          <option value="MG">MG</option>
          <option value="PA">PA</option>
          <option value="PB">PB</option>
          <option value="PR">PR</option>
          <option value="PE">PE</option>
          <option value="PI">PI</option>
          <option value="RJ">RJ</option>
          <option value="RN">RN</option>
          <option value="RS">RS</option>
          <option value="RO">RO</option>
          <option value="RR">RR</option>
          <option value="SC">SC</option>
          <option value="SP">SP</option>
          <option value="SE">SE</option>
          <option value="TO">TO</option>
        </C.Select>
        <Input
          type="cidade"
          placeholder="Insira sua cidade"
          value={cidadeAdvogado}
          onChange={(e) => [setCidadeAdvogado(e.target.value), setErrorAdvogado("")]}
        />
        <Input
          type="ID"
          placeholder="ID OAB"
          value={idOAB}
          onChange={(e) => [setID(e.target.value), setErrorAdvogado("")]}
        />
         <C.Select value={categoria} onChange={handleCategoria} hasValue={categoria !== ""}>
          
          <option value="">Selecione a sua categoria</option>
          <option value="Cível">Cível</option>
          <option value="Trabalhista">Trabalhista</option>
          <option value="Imobiliário">Imobiliário</option>
          <option value="Ambientalista">Ambientalista</option>
          <option value="Consumidor">Consumidor</option> 
          <option value="Criminalista">Criminalista</option>
          <option value="Tributário">Tributário</option>
          <option value="Previdenciário">Previdenciário</option>         
        </C.Select>
        <Input
          type="idade"
          placeholder="Idade"
          value={idade}
          onChange={(e) => [setIdade(e.target.value), setErrorAdvogado("")]}
        />
        <Input
          type="password"
          placeholder="Digite sua Senha"
          value={senhaAdvogado}
          onChange={(e) => [setSenhaAdvogado(e.target.value), setErrorAdvogado("")]}
        />
        <C.labelError>{errorAdvogado}</C.labelError>
        <Button Text="Cadastrar" onClick={() => handleSignup(true)} />
        <C.LabelSignin>
          Já tem uma conta?
          <C.Strong>
            <Link to="/"> Entre</Link>
          </C.Strong>
        </C.LabelSignin>
      </C.Content>
    </C.Container>
    </>
  );
};

export default Signup;