// import { StatusBar } from 'expo-status-bar';
import React, { Component } from 'react';
import { FlatList, Image, StyleSheet, Text, View } from 'react-native';

export default class Login extends Component {
  constructor(props){
      super(props);
      this.state = {
          email : '',
          senha : ''
      }
  }

  realizarLogin = async () => {
      console.warn( this.state.email + ' ' + this.state.senha );

      const resposta = await api.post('/login', {
          email : this.state.email,
          senha : this.state.senha
      });

      const token = resposta.data.token;
      console.warn(token);

      await AsyncStorage.setItem('userToken', token);

      this.props.navigation.navigate('Main');
  };

  render(){
      return (
         
              // <View style={styles.overlay} />
              <View style={styles.main}>

                  <TextInput 
                      style={styles.inputLogin}
                      placeholder='E-mail'
                      placeholderTextColor='#FFF'
                      keyboardType='email-address'
                      onChangeText={email => this.setState({ email })}
                  />

                  <TextInput 
                      style={styles.inputLogin}
                      placeholder='Senha'
                      placeholderTextColor='#FFF'
                      secureTextEntry={true}
                      onChangeText={senha => this.setState({ senha })}
                  />

                  <TouchableOpacity
                      style={styles.btnLogin}
                      onPress={this.realizarLogin}
                  >
                      <Text style={styles.btnLoginText}>login</Text>
                  </TouchableOpacity>

              </View>

      );
  }
}

