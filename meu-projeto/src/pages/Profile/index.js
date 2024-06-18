import React, { useState } from "react"
import { useNavigate } from "react-router-dom";
import useAuth from "../../hooks/useAuth";
import * as C from "./styles"; // Certifique-se de que os componentes estão exportados corretamente aqui
import logo from "../../img/logo.png";
import styled from 'styled-components';
import { GlobalStyle } from './styles';
import maicon from "../../img/maicon.png"
import leojardim from "../../img/leojardim.png";

const Profile = () => {
  const { signout } = useAuth();
  const navigate = useNavigate();
 
  const handleLogout = () => {
    signout(); // Isso irá limpar quaisquer tokens de autenticação
    navigate('/signin'); // Isso irá redirecionar o usuário para a tela de login
  };

  return (
    <>
      <GlobalStyle />
      <C.LogoutButton onClick={handleLogout}>SAIR</C.LogoutButton>
      <C.logo src = {logo} alt="logo" title="logo"/>
      <C.TopBar />
      <C.Container>
        <C.ProfileCard>
          <C.ProfileImage src={leojardim} alt="Leo Jardim" />
          <C.ProfileName>
            Leo Jardim
            <C.ProfileDetails>Especialista em direito criminal</C.ProfileDetails>
          </C.ProfileName>
          <C.Button onClick={() => navigate('/profile')}>Entrar em contato</C.Button>
        </C.ProfileCard>
        <C.InfosCard>
          <C.InfoTitle>Email:</C.InfoTitle>
          <C.InfoText>leojardim@gmail.com</C.InfoText>
          <C.InfoTitle>Idade:</C.InfoTitle>
          <C.InfoText>37 anos</C.InfoText>
          <C.InfoTitle>Cidade:</C.InfoTitle>
          <C.InfoText>Jaguaré - ES</C.InfoText>
        </C.InfosCard>
        <C.InfoSobre>
          <C.InfoTitle>Sobre:</C.InfoTitle>
          <C.InfoText>Ele comegou com seis anos, como recreacdo, e nesse periodo ele jogava na linha. Depois ele foi para o gol e ndo saiu mais. Ai colocamos ele no Botafogo-
          SP, porque ele comegou a levar mais a sério, mesmo novo, sé que ele tinha que passar por um aprendizado. Levamos ele para o Botafogo por conta do
          treinador de goleiros, o Leandro Franco.Ele comegou com seis anos, como recreacdo, e nesse periodo ele jogava na linha. Depois ele foi para o gol e ndo saiu mais. Ai colocamos ele no Botafogo-
          SP, porque ele comegou a levar mais a sério, mesmo novo, sé que ele tinha que passar por um aprendizado. Levamos ele para o Botafogo por conta do
          treinador de goleiros, o Leandro Franco.Ele comegou com seis anos, como recreacdo, e nesse periodo ele jogava na linha. Depois ele foi para o gol e ndo saiu mais. Ai colocamos ele no Botafogo-
          SP, porque ele comegou a levar mais a sério, mesmo novo, sé que ele tinha que passar por um aprendizado. Levamos ele para o Botafogo por conta do
          treinador de goleiros, o Leandro Franco.</C.InfoText>
        </C.InfoSobre>
        <C.InfoAtuacao>
          <C.InfoTitle>Áreas de atuação:</C.InfoTitle>
          <C.InfoText>-Direito criminal</C.InfoText>
          <C.InfoText>-Direito do consumidor</C.InfoText>
        </C.InfoAtuacao>
      </C.Container>
    </>
  );
};

export default Profile;
