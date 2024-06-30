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
  padding-left: 0vh;
  height: 100vh;
  width: 100vw; // Adicionado para ocupar toda a largura da tela
  overflow: hidden; // Adicionado para evitar rolagem
  background-color: #F5F5F5; // Altere para a cor de fundo desejada
`;

export const TopBar = styled.div`
  width: 100%;
  height: 9vh; // Ajuste a altura conforme necessário
  background-color: #1C1C1C; // Ajuste a cor conforme necessário
  positon: fixed
  top: 0;
  left: 0;
  z-index: 1000; // Isso garante que a barra esteja sempre no topo
`;
export const logo = styled.img`
  position: absolute;
  width: 17.15vh; /* Defina a largura desejada */
  height: 10.4vh; /* Mantém a proporção da imagem */
  display: block; /* Garante que a imagem seja um bloco */
  margin-left: 0.8vh;
  margin-top: -0.6vh;
`;
export const LogoutButton = styled.button`
  position: absolute;
  right: 10vh; // Ajuste conforme necessário
  top: 3vh; // Ajuste conforme necessário
  background: none;
  color: #FFFFFF; /* Cor do texto */
  border: none;
  cursor: pointer;
  font-size: 2vh; /* Ajuste o tamanho da fonte conforme necessário */
  &:hover {
    opacity: 0.8;
  }
`;
export const NavigationTab = styled.div`
  display: inline-block;
  color: #FFFFFF;
  padding: 1vh 2vh;
  cursor: pointer;
  &:hover {
    background-color: #333333;
  }
`;

export const InfosCard = styled.div`
  flex-direction: line;
  margin-left: 2vh;
  margin-top: 1vh;
  display: flex;
  width: 98%;
  height: 25vh;
  padding: 4vh;
  max-padding: 5vh;
  background-color: #FFF; // Altere para a cor de fundo desejada
  box-shadow: 0vh 0.5vh 1vh rgba(0, 0, 0, 0.1); // Altere para a sombra desejada
  border-radius: 1vh; // Altere para o raio de borda desejado
  margin-bottom: 1vh;
  gap: 1vh;
  border: black;
`;

export const ProfileCard = styled.div`
  margin-left: 2vh;
  margin-top: 2vh;
  display: flex;
  width: 98%;
  height: 15vh;
  padding: 4vh;
  max-padding: 5vh;
  background-color: #1C1C1C; // Altere para a cor de fundo desejada
  box-shadow: 0vh 0.5vh 1vh rgba(0, 0, 0, 0.1); // Altere para a sombra desejada
  border-radius: 1vh; // Altere para o raio de borda desejado
  margin-bottom: 1vh;
  gap: 1vh;
`;

export const ProfileImage = styled.img`
  margin-top: -2vh;
  width: 10vh;
  height: 10vh;
  border-radius: 50%;
  object-fit: cover;
`;

export const ProfileName = styled.p`
  width: 180%;
  margin-left: 2vh;
  font-size: 2.9vh;
  font-weight: bold;
  color: #FFF; // Altere para a cor desejada
  margin-top: -2vh;
`;

export const ProfileDetails = styled.p`
  margin-top: 1vh;
  font-size: 1.6vh;
  color: #FFF; // Altere para a cor desejada
`;

export const ProfileDescription = styled.p`
  position: center;
  margin-left: 20.3vh;
  font-size: 1.5vh;
  color: #1D1D1D; // Altere para a cor desejada
  max-width: 52.5vh;
  margin-top: 1vh;
`;

export const Button = styled.button`
  height: 6vh;
  width: 200vh;
  margin-top: 0.6vh;
  margin-left: 130vh;
  outline: none;
  border: none;
  border-radius: 1vh;
  cursor: pointer;
  background-color: #FFF;
  font-weight: bold;
  color: black;
  font-size: 2vh;
`;


export const InfoTitle = styled.p`
  font-size: 2vh;
  font-weight: bold;
  color: #4F4F4F; 
  
`;
export const InfoText = styled.p`
  margin-left: 1.6vh;
  margin-top: 1vh;
  margin-bottom: 1vh;
  font-size: 1.6vh;
  font-weight: bold;
  color: #00000; 
`

export const InfoSobre = styled.div`
  flex-direction: column;
  margin-left: 2vh;
  margin-top: 1vh;
  display: flex;
  width: 98%;
  height: 20vh;
  padding: 4vh;
  max-padding: 5vh;
  background-color: #FFF; // Altere para a cor de fundo desejada
  box-shadow: 0vh 0.5vh 1vh rgba(0, 0, 0, 0.1); // Altere para a sombra desejada
  border-radius: 1vh; // Altere para o raio de borda desejado
  margin-bottom: 1vh;
  gap: 1vh;
  border: black;
`;

export const Info = styled.div`
  flex-direction: line;
  width: 100vh;
`;


export const InfoAtuacao = styled.div`
  flex-direction: line;
  margin-left: 2vh;
  margin-top: 1vh;
  display: flex;
  width: 98%;
  height: 20vh;
  padding: 4vh;
  max-padding: 5vh;
  background-color: #FFF; // Altere para a cor de fundo desejada
  box-shadow: 0vh 0.5vh 1vh rgba(0, 0, 0, 0.1); // Altere para a sombra desejada
  border-radius: 1vh; // Altere para o raio de borda desejado
  margin-bottom: 1vh;
  gap: 1vh;
  border: black;
`;


export const TelaInteira = styled.div`
  display: flex;
  flex-direction: line;
  justify-content: flex-start;
  padding-left: 0vh;
  height: 100vh;
  width: 100vw; // Adicionado para ocupar toda a largura da tela
  overflow: hidden; // Adicionado para evitar rolagem
  background-color: #F5F5F5; // Altere para a cor de fundo desejada
`;

export const Chat = styled.div`
  height: 42%;
  width: 25vh;
  display: flex;
  flex-direction: column;
  gap: 2vh;
  margin-left: 3vh;
  margin-top: 2vh;
  max-width: 25vh;
  padding: 2vh; //distancia no inicio do bloco
  background-color: #FFF; // Altere para a cor de fundo desejada
  box-shadow: 0vh 0.5vh 1vh rgba(0, 0, 0, 0.1); // Altere para a sombra desejada
  border-radius: 1vh; // Altere para o raio de borda desejado
  margin-bottom: 55vh;
`;

export const ChatCard = styled.div`
  margin-left: 0vh;
  margin-top: 0vh;
  display: flex;
  width: 98%;
  height: 10%;
  padding: 1vh;
  max-padding: 5vh;
  background-color: #DCDCDC; // Altere para a cor de fundo desejada
  box-shadow: 0vh 0.8vh 1vh rgba(0, 0, 0, 0.1); // Altere para a sombra desejada
  border-radius: 1vh; // Altere para o raio de borda desejado
  cursor: pointer;
`;


export const ElementChat = styled.div`
  font-size: 2vh;
  font-weight: bold;
  color: #4F4F4F; 
`;