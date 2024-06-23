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
  const [emailConf, setEmailConf] = useState("");
  const [cpf, setCPF] = useState("");
  const [cep, setCEP] = useState("");
  const [senha, setSenha] = useState("");
  const [error, setError] = useState("");

  const [nomeAdvogado, setNomeAdvogado] = useState("");
  const [emailAdvogado, setEmailAdvogado] = useState("");
  const [emailConfAdvogado, setEmailConfAdvogado] = useState("");
  const [cpfAdvogado, setCPFAdvogado] = useState("");
  const [cepAdvogado, setCEPAdvogado] = useState("");
  const [idOAB, setID] = useState("");
  const [senhaAdvogado, setSenhaAdvogado] = useState("");
  const [errorAdvogado, setErrorAdvogado] = useState("");

  const navigate = useNavigate();

  const { signup } = useAuth();

  const handleSignup = (isAdvogado = false) => {
    let emailToUse = isAdvogado ? emailAdvogado : email;
    let emailConfToUse = isAdvogado ? emailConfAdvogado : emailConf;
    let senhaToUse = isAdvogado ? senhaAdvogado : senha;
    let setErrorFunc = isAdvogado ? setErrorAdvogado : setError;

    if (!emailToUse | !emailConfToUse | !senhaToUse) {
      setErrorFunc("Preencha todos os campos");
      return;
    } else if (emailToUse !== emailConfToUse) {
      setErrorFunc("Os e-mails não são iguais");
      return;
    }

    const res = signup(emailToUse, senhaToUse);

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
          type="email"
          placeholder="Confirme seu E-mail"
          value={emailConf}
          onChange={(e) => [setEmailConf(e.target.value), setError("")]}
        />
        <Input
          type="cpf"
          placeholder="CPF"
          value={cpf}
          onChange={(e) => [setCPF(e.target.value), setError("")]}
        />
        <Input
          type="cep"
          placeholder="Insira seu CEP"
          value={cep}
          onChange={(e) => [setCEP(e.target.value), setError("")]}
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
          type="email"
          placeholder="Confirme seu E-mail"
          value={emailConfAdvogado}
          onChange={(e) => [setEmailConfAdvogado(e.target.value), setErrorAdvogado("")]}
        />
        <Input
          type="cpf"
          placeholder="CPF"
          value={cpfAdvogado}
          onChange={(e) => [setCPFAdvogado(e.target.value), setErrorAdvogado("")]}
        />
        <Input
          type="cep"
          placeholder="Insira seu CEP"
          value={cepAdvogado}
          onChange={(e) => [setCEPAdvogado(e.target.value), setErrorAdvogado("")]}
        />
        <Input
          type="text"
          placeholder="ID OAB"
          value={idOAB}
          onChange={(e) => [setID(e.target.value), setErrorAdvogado("")]}
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