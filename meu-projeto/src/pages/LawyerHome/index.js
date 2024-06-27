import { useNavigate, useParams } from "react-router-dom";
import useAuth from "../../hooks/useAuth";
import * as C from "./styles"; // Certifique-se de que os componentes estão exportados corretamente aqui
import logo from "../../img/logo.png";
import styled from 'styled-components';
import { GlobalStyle } from './styles';
import leojardim from "../../img/leojardim.png";
import React, { useState, useEffect } from 'react';

const LawyerHome = () => {
  const { signout } = useAuth();
  const navigate = useNavigate();
 
  const handleLogout = () => {
    signout(); // Isso irá limpar quaisquer tokens de autenticação
    navigate('/signin'); // Isso irá redirecionar o usuário para a tela de login
  };

  let { lawyerId } = useParams();
  console.log(lawyerId);
  
  return (
    <>
      <GlobalStyle />
      <C.LogoutButton onClick={handleLogout}>SAIR</C.LogoutButton>
      <C.logo src = {logo} alt="logo" title="logo"/>
      <C.TopBar />
      <C.TelaInteira>
        <C.Chat> 
            <C.ChatCard>
                <C.ElementChat>Editar perfil</C.ElementChat>
            </C.ChatCard>
            <C.ChatCard>
                <C.ElementChat>Chat</C.ElementChat>
            </C.ChatCard>
            <C.ChatCard>
                <C.ElementChat>Solicitações</C.ElementChat>
            </C.ChatCard>
        </C.Chat>
        <C.Container>
            <C.ProfileCard>
                <C.ProfileImage src={leojardim} alt="Leo Jardim" />
                <C.ProfileName>
                    Leo Jardins
                    <C.ProfileDetails>Especialista em direito criminal</C.ProfileDetails>
                </C.ProfileName>
                
            </C.ProfileCard>
            <C.InfosCard> 
                <C.Info>
                    <C.InfoTitle>Email:</C.InfoTitle>
                    <C.InfoText>leojardim@gmail.com</C.InfoText>
                    <C.InfoTitle>Idade:</C.InfoTitle>
                    <C.InfoText>37 anos</C.InfoText>
                    <C.InfoTitle>Cidade:</C.InfoTitle>
                    <C.InfoText>Jaguaré - ES</C.InfoText>
                </C.Info>
            </C.InfosCard>
            <C.InfoSobre>
   
                    <C.InfoTitle>Sobre:</C.InfoTitle>
                    <C.InfoText>Ele comegou com seis anos, como recreacdo, e nesse periodo ele jogava na linha. Depois ele foi para o gol e ndo saiu mais. Ai colocamos ele no Botafogo-
                        SP, porque ele comegou a levar mais a sério, mesmo novo, sé que ele tinha que passar por um aprendizado. Levamos ele para o Botafogo por conta do
                        treinador de goleiros, o Leandro Franco.Ele comegou com seis anos, como recreacdo, e nesse periodo ele jogava na linha. Depois ele foi para o gol e ndo saiu mais. Ai colocamos ele no Botafogo-
                        SP, porque ele comegou a levar mais a sério, mesmo novo, sé que ele tinha que passar por um aprendizado. Levamos ele para o Botafogo por conta do
                        treinador de goleiros, o Leandro Franco.Ele comegou com seis anos, como recreacdo, e nesse periodo ele jogava na linha. Depois ele foi para o gol e ndo saiu mais. Ai colocamos ele no Botafogo-
                        SP, porque ele comegou a levar mais a sério, mesmo novo, sé que ele tinha que passar por um aprendizado. Levamos ele para o Botafogo por conta do
                        treinador de goleiros, o Leandro Franco.
                    </C.InfoText>
            </C.InfoSobre>
            <C.InfoAtuacao>
                <C.Info>
                    <C.InfoTitle>Áreas de atuação:</C.InfoTitle>
                    <C.InfoText>-Direito criminal</C.InfoText>
                    <C.InfoText>-Direito do consumidor</C.InfoText>
                </C.Info>
            </C.InfoAtuacao>
        </C.Container>
    </C.TelaInteira>
    </>
  );
};

export default LawyerHome;
