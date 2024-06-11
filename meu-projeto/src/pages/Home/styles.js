import styled from "styled-components";
import { createGlobalStyle } from 'styled-components';

export const GlobalStyle = createGlobalStyle`
  body {
    overflow: hidden;
    margin: 0;
    padding: 0;
  }
`

export const Container = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  padding-left: 0px;
  height: 100vh;
  width: 100vw; // Adicionado para ocupar toda a largura da tela
  overflow: hidden; // Adicionado para evitar rolagem
  background-color: #F5F5F5; // Altere para a cor de fundo desejada
`;


export const Title = styled.h1`
  font-size: 24px;
  font-weight: bold;
  color: #333; // Altere para a cor desejada
`;

export const SearchCard = styled.div`
  margin-left: 50px;
  margin-top:20px;
  display: flex;
  flex-direction: line;
  align-items: left;
  width: 100%;
  max-width: 350px;
  padding-left: 50px;
  background-color: #FFF; // Altere para a cor de fundo desejada
  box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1); // Altere para a sombra desejada
  border-radius: 10px; // Altere para o raio de borda desejado
  margin-bottom: 450px;
`;

export const TelaInteira = styled.div`
  display: flex;
  flex-direction: line;
  justify-content: flex-start;
  padding-left: 0px;
  height: 100vh;
  width: 100vw; // Adicionado para ocupar toda a largura da tela
  overflow: hidden; // Adicionado para evitar rolagem
  background-color: #F5F5F5; // Altere para a cor de fundo desejada
`;

export const ProfileCard = styled.div`
  margin-left: 130px;
  margin-top: 20px;
  display: flex;
  flex-direction: line;
  align-items: left;
  width: 100%;
  max-width: 1300px;
  padding: 40px;
  max-padding: 40px;
  background-color: #FFF; // Altere para a cor de fundo desejada
  box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1); // Altere para a sombra desejada
  border-radius: 10px; // Altere para o raio de borda desejado
  margin-bottom: 20px;
  gap: 10px;
`;

export const ProfileImage = styled.img`
  width: 150px;
  height: 150px;
  border-radius: 50%;
  object-fit: cover;
`;

export const ProfileName = styled.h2`
  margin-left: 15px;
  font-size: 18px;
  font-weight: bold;
  color: #333; // Altere para a cor desejada
  margin-top: 10px;
  max-width: 150px;
`;

export const ProfileDetails = styled.p`
  margin-top: 8px;
  font-size: 15px;
  color: #1C1C1C; // Altere para a cor desejada
`;

export const ProfileDescription = styled.p`
  position: center;
  margin-left: 300px;
  font-size: 14px;
  color: #1D1D1D; // Altere para a cor desejada
  max-width: 500px;
  margin-top: 10px;
`;

export const TopBar = styled.div`
  width: 100%;
  height: 80px; // Ajuste a altura conforme necessário
  background-color: #1C1C1C; // Ajuste a cor conforme necessário
  positon: fixed
  top: 0;
  left: 0;
  z-index: 1000; // Isso garante que a barra esteja sempre no topo
`;
export const logo = styled.img`
  position: absolute;
  width: 179px; /* Defina a largura desejada */
  height: 110px; /* Mantém a proporção da imagem */
  display: block; /* Garante que a imagem seja um bloco */
  margin-left: 15px;
  margin-top: -14px;
`;
export const LogoutButton = styled.button`
  position: absolute;
  right: 100px; // Ajuste conforme necessário
  top: 27px; // Ajuste conforme necessário
  background: none;
  color: #FFFFFF; /* Cor do texto */
  border: none;
  cursor: pointer;
  font-size: 18px; /* Ajuste o tamanho da fonte conforme necessário */
  &:hover {
    opacity: 0.8;
  }
`;

