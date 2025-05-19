import { useEffect } from 'react';
import { useGLTF } from '@react-three/drei';

export default function Lamp() {
    const { scene } = useGLTF('/models/lamp.glb');

    return <primitive object={scene} scale={5} position={[9, 0, 5]} />;
}