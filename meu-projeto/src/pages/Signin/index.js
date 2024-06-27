import React, { useState, useEffect } from "react";
import Input from "../../components/Input";
import Button from "../../components/Button";
import * as C from "./styles";
import { Link, useNavigate } from "react-router-dom";
import useAuth from "../../hooks/useAuth";
import logo from "../../img/logo.png";
import logozinho from "../../img/logozinho.png";

const Signin = () => {
  // const { signin } = useAuth();
  const navigate = useNavigate();

  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");
  const [error, setError] = useState("");

  // const handleLogin = () => {
  //   if (!email | !senha) {
  //     setError("Preencha todos os campos");
  //     return;
  //   }
  //   const res = signin(email, senha);

  //   if (res) {
  //     setError(res);
  //     return;
  //   }

  //   navigate("/home");
  // };

  // Já que não temos uma tabela de users, vamos fazer uma requisição para a API para os dois tipos de usuários.
  // Bug já mapeado: se o usuário for tanto cliente quanto advogado, não sabemos qual será o resultado k.
  const [cpf, setCpf] = useState("");
  const fetchLogin = async () => {
    const url_lawyer = `http://localhost:5001/api/v1/lawyer/get?email=${email}&password=${senha}&cpf=${cpf}`;
    const url_client = `http://localhost:5001/api/v1/client/get?email=${email}&password=${senha}&cpf=${cpf}`;
    if (!email || !senha || !cpf) {
      setError("Preencha todos os campos");
      return;
    }
    try {
      const response_lawyer = await fetch(url_lawyer);
      const response_client = await fetch(url_client);
  
      if (response_lawyer.ok) {
        const data = await response_lawyer.json();
        console.log("Lawyer API Response:", data);
        navigate("/Home");
      }else if (response_client.ok) {
        const data = await response_client.json();
        console.log("Client Response:", data);
        navigate("/Home");
      }
    } catch (error) {
      console.error("Error during login:", error);
      setError("Erro ao fazer login. Por favor, tente novamente."); // Display a generic error message
    }
  };
  
  return (
    <>
    <C.Logozinho src = {logozinho} alt="Logozinho" title="Logozinho"/>
    <C.Container>
    <img src = {logo} alt="Logo" title="Logo" />
      <C.Content>
        <Input
          type="email"
          placeholder="Digite seu E-mail"
          value={email}
          onChange={(e) => [setEmail(e.target.value), setError("")]}
        />
        <Input
          type="cpf"
          placeholder="Digite seu CPF"
          value={cpf}
          onChange={(e) => [setCpf(e.target.value), setError("")]}
        />
        <Input
          type="password"
          placeholder="Digite sua Senha"
          value={senha}
          onChange={(e) => [setSenha(e.target.value), setError("")]}
        />
        <C.labelError>{error}</C.labelError>
        <Button Text="Entrar" onClick={fetchLogin} />
        <C.LabelSignup>
          Não tem uma conta?
          <C.Strong>
            <Link to="/signup">&nbsp;Registre-se</Link>
          </C.Strong>
        </C.LabelSignup>
      </C.Content>
    </C.Container>
    </>
  );
};

export default Signin;