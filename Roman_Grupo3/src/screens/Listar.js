import React, { Component } from 'react';
import { FlatList, Image, StyleSheet, Text, View } from 'react-native';

import api from '../services/api.js';


export default class App extends Component{
  constructor(props){
    super(props);
    this.state ={
      listarProjetos: [],
    };
  }
  
  buscarProjetos = async () => {
    const resposta = await api.get('/Projetos');
    const dadosApi = resposta.data;
    this.setState ({listarProjetos: dadosApi});
  };

  componentDidMount(){
    this.buscarProjetos ();
  }

  render(){
    return(
      <View style={styles.main}>
        <Text>{'Listas'.toUpperCase ()}</Text>

        <View>
          <FlatList
          contentContainerStyle={mainBodyConteudo}
          data = {this.state.listarProjetos}
          keyExtractor = {(item) => item.nomeProjeto}
          renderItem={this.renderizaItem}
          />
        </View>

      </View>
    );
  }
  renderizaItem = ({item}) => (
    <View style={styles.flatItemLinha}>
      <Text>{item.nomeProfessor}</Text>
      <Text>{item.nomeProjeto}</Text>
      <Text>{item.nomeTema}</Text>
    </View>
  );

}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
  mainBodyConteudo:{
    paddingTop: 30,
    paddingRight: 50,
    paddingLeft: 50,
  },

  flatItemLinha:{
    flexDirection: 'row',
    borderBottomWidth: 0.9,
    borderBottomColor: 'white'
  }
});