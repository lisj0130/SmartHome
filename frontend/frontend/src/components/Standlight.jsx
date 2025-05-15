import { useEffect } from 'react';
import { useGLTF } from '@react-three/drei';

export default function Standlight() {
    const { scene } = useGLTF('/models/standlight.glb');

    return <primitive object={scene} scale={5} position={[-8.8, -3, -8.5]}/>;
}